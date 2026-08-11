using Day1WebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsetController : ControllerBase
    {
        private readonly IAsetService _asetService;

        public AsetController(IAsetService asetService)
        {
            _asetService = asetService;
        }

        [HttpGet]
        public IActionResult GetAllAset()
        {
            return Ok(_asetService.GetAllAset());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var aset = await _asetService.GetById(id);
            return aset == null ? NotFound() : Ok(aset);
        }

        [HttpPost]
        public IActionResult CreateAset(AsetParamDto asetParam)
        {
            try
            {
                return Ok(_asetService.CreateAset(asetParam));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAset(Guid id, [FromBody] AsetParamDto asetParam)
        {
            try
            {
                return Ok(_asetService.UpdateAset(id, asetParam));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteAset(Guid id)
        {
            try
            {
                _asetService.DeleteAset(id);
                return Ok("Delete Aset berhasil");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
