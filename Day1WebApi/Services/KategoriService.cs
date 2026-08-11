using AutoMapper;
using Day1WebApi.Data;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Services
{
    public class KategoriService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public KategoriService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public List<Kategori> GetAllKategori()
        {
            return _appDbContext.Kategori.AsNoTracking().ToList();
        }

        public Kategori? GetKategoriById(Guid id)
        {
            return _appDbContext.Kategori.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Kategori TambahKategori(KategoriDto kategoriParam)
        {
            var kategori = _mapper.Map<Kategori>(kategoriParam);
            _appDbContext.Kategori.Add(kategori);
            _appDbContext.SaveChanges();
            return kategori;
        }


        public Kategori? UpdateKategori(Guid id, KategoriDto kategoriParam)
        {
            var kategori = _appDbContext.Kategori.Find(id);
            if (kategori == null) return null;
            kategori.Nama = kategoriParam.Nama;
            _appDbContext.Kategori.Update(kategori);
            _appDbContext.SaveChanges();
            return kategori;
        }

        public void DeleteKategori(Guid id)
        {
            var kategori = _appDbContext.Kategori.Find(id);
            if (kategori == null) throw new Exception("Kategori tidak ditemukan");
            _appDbContext.Kategori.Remove(kategori);
            _appDbContext.SaveChanges();
        }
    }
}
