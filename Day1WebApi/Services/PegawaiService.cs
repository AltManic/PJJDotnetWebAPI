using AutoMapper;
using Day1WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Services
{
    public class PegawaiService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public PegawaiService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public List<Pegawai> GetAllPegawai()
        {
            return _appDbContext.Pegawai.AsNoTracking().ToList();
        }

        public Pegawai GetById(Guid id)
        {
            return _appDbContext.Pegawai.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Pegawai CreatePegawai(PegawaiDto pegawaiParam)
        {
            var pegawai = _mapper.Map<Pegawai>(pegawaiParam);
            _appDbContext.Pegawai.Add(pegawai);
            _appDbContext.SaveChanges();
            return pegawai;
        }

        public Pegawai UpdatePegawai(Guid id, PegawaiDto pegawaiDto)
        {
            var pegawai = _appDbContext.Pegawai.Find(id);
            if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
            pegawai.Nama = pegawaiDto.Nama;
            pegawai.NIP = pegawaiDto.NIP;
            pegawai.Jabatan = pegawaiDto.Jabatan;
            pegawai.Gaji = pegawaiDto.Gaji;
            pegawai.TanggalMasuk = pegawaiDto.TanggalMasuk;
            _appDbContext.Pegawai.Update(pegawai);
            _appDbContext.SaveChanges();
            return pegawai;
        }

        public void DeletePegawai(Guid id)
        {
            var pegawai = _appDbContext.Pegawai.Find(id);
            if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
            _appDbContext.Pegawai.Remove(pegawai);
            _appDbContext.SaveChanges();
        }
    }
}
