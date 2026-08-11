using AutoMapper;
using Day1WebApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PegawaiController : ControllerBase
    {
        private readonly IMapper _mapper;
        public PegawaiController(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Pegawai> Pegawai = new List<Pegawai>()
        {
            new Pegawai()
                {
                    Nama = "Budi",
                    NIP = "1234567890",
                    Jabatan = "Manager",
                    Gaji = 10000000,
                    TanggalMasuk = new DateOnly(2020, 1, 1)
                },
                new Pegawai()
                {
                    Nama = "Siti",
                    NIP = "0987654321",
                    Jabatan = "Staff",
                    Gaji = 5000000,
                    TanggalMasuk = new DateOnly(2021, 1, 1)
                }
        };

        [SampleFilter]
        [HttpGet]
        public IActionResult GetAll([FromQuery] PegawaiQueryParam pegawaiQueryParam)
        {
            Console.WriteLine("GetAll method called");
            var tempListPegawai = Pegawai.ToList();
            if(pegawaiQueryParam.Nama != null)
            {
                tempListPegawai = tempListPegawai.Where(x => x.Nama.ToLower().Contains(pegawaiQueryParam.Nama.ToLower())).ToList();
            }

            if(pegawaiQueryParam.Nip != null)
            {
                tempListPegawai = tempListPegawai.Where(x => x.NIP.ToLower().Contains(pegawaiQueryParam.Nip.ToLower())).ToList();
            }
            var pegawaiDtos = _mapper.Map<List<PegawaiDto>>(tempListPegawai);
            return Ok(pegawaiDtos);
        }
        
        [HttpGet("{id}")]
        
        public IActionResult GetById(Guid id)
        {
            var pegawai = Pegawai.FirstOrDefault(x => x.Id == id);
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
            var pegawai = _mapper.Map<Pegawai>(pegawaiParam);
            Pegawai.Add(pegawai);
            var pegawaiDtoResult = _mapper.Map<PegawaiDto>(pegawai);
            return Ok(pegawaiDtoResult);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePegawai(Guid id, PegawaiDto pegawaiParam)
        {
            var pegawai = Pegawai.FirstOrDefault(x => x.Id == id);
            if (pegawai == null)
            {
                return NotFound();
            }
            pegawai.Nama = pegawaiParam.Nama;
            pegawai.NIP = pegawaiParam.NIP;
            pegawai.Jabatan = pegawaiParam.Jabatan;
            pegawai.Gaji = pegawaiParam.Gaji;
            pegawai.TanggalMasuk = pegawaiParam.TanggalMasuk;

            var pegawaiDtoResult = _mapper.Map<PegawaiDto>(pegawai);
            return Ok(pegawaiDtoResult);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePegawai(Guid id)
        {
            var pegawai = Pegawai.FirstOrDefault(x => x.Id == id);
            if(pegawai == null)
            {
                return NotFound();
            }
            Pegawai.Remove(pegawai);
            return Ok($"Hapus pegawai dengan nama {pegawai.Nama} berhasil");
        }
    }
}
