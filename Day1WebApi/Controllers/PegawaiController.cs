using AutoMapper;
using Day1WebApi.Filters;
using Day1WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PegawaiController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly PegawaiService _pegawaiService;
        public PegawaiController(IMapper mapper, PegawaiService pegawaiService)
        {
            _mapper = mapper;
            _pegawaiService = pegawaiService;
        }


        [SampleFilter]
        [HttpGet]
        public IActionResult GetAll([FromQuery] PegawaiQueryParam pegawaiQueryParam)
        {
            var tempListPegawai = _pegawaiService.GetAllPegawai();
            var pegawaiDtos = _mapper.Map<List<PegawaiDto>>(tempListPegawai);
            return Ok(pegawaiDtos);
        }
        
        [HttpGet("{id}")]
        
        public IActionResult GetById(Guid id)
        {
            var pegawai = _pegawaiService.GetById(id);
            if (pegawai == null)
            {
                return NotFound();
            }
            var pegawaiDto = _mapper.Map<PegawaiDto>(pegawai);
            return Ok(pegawaiDto);
        }

        [HttpPost]
        public IActionResult CreatePegawai(PegawaiDto pegawaiParam)
        {
            var pegawai = _pegawaiService.CreatePegawai(pegawaiParam);
            
            var pegawaiDtoResult = _mapper.Map<PegawaiDto>(pegawai);
            return Ok(pegawaiDtoResult);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePegawai(Guid id, PegawaiDto pegawaiParam)
        {
            var pegawai = _pegawaiService.UpdatePegawai(id, pegawaiParam;
          
            var pegawaiDtoResult = _mapper.Map<PegawaiDto>(pegawai);
            return Ok(pegawaiDtoResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePegawai(Guid id)
        {
            _pegawaiService.DeletePegawai(id);
            return Ok($"Hapus pegawai dengan nama berhasil");
        }
    }
}
