using AutoMapper;
using Day1WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Services
{
    public class PegawaiService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PegawaiService(AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public PaginationResponse<Pegawai> GetAllPegawai(PegawaiQueryParam pegawaiQueryParam)
        {
            var pegawai = _appDbContext.Pegawai.AsNoTracking().AsQueryable();
            if (pegawaiQueryParam.Nama != null)
            {
                pegawai = pegawai.Where(p => p.Nama.ToLower().Contains(pegawaiQueryParam.Nama.ToLower()));
            }
            var count = pegawai.Count();
            var data = pegawai.Skip(pegawaiQueryParam.Offset).Take(pegawaiQueryParam.Limit).ToList();
            return new PaginationResponse<Pegawai>()
            {
                Total = count,
                Data = data
            };
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
            var pegawai = _appDbContext.Pegawai.FirstOrDefault(x => x.Id == id);
            if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
            pegawai.Nama = pegawaiDto.Nama;
            pegawai.Jabatan = pegawaiDto.Jabatan;
            pegawai.NIP = pegawaiDto.NIP;
            pegawai.TanggalMasuk = pegawaiDto.TanggalMasuk.Value;
            pegawai.Gaji = pegawaiDto.Gaji.Value;
            _appDbContext.SaveChanges();
            return pegawai;
        }

        public Pegawai PartialUpdatePegawai(Guid id, PegawaiDto pegawaiParam)
        {
            var pegawai = _appDbContext.Pegawai.FirstOrDefault(x => x.Id == id);
            if (pegawai == null) throw new Exception("Pegawai tidak ditemukan");
            _appDbContext.Update(pegawai);
            _appDbContext.PartialUpdate(pegawaiParam, pegawai);
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