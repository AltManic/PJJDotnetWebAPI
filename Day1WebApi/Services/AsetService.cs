using AutoMapper;
using Day1WebApi.Data;
using Day1WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Services
{
    public class AsetService : IAsetService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public AsetService(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AsetDto CreateAset(AsetParamDto asetParam)
        {
            var aset = _mapper.Map<Aset>(asetParam);
            var kategori = _dbContext.Kategori.FirstOrDefault(x => x.Id == aset.KategoriId);
            if(kategori == null)
            {
                throw new Exception("Kategori tidak ditemukan");
            }
            _dbContext.Add(aset);
            _dbContext.SaveChanges();
            return _mapper.Map<AsetDto>(aset);
        }

        public void DeleteAset(Guid id)
        {
            var aset = _dbContext.Aset.Find(id);
            if(aset == null)
            {
                throw new Exception("Aset tidak ditemukan");
            }
            _dbContext.Remove(aset);
            _dbContext.SaveChanges();
        }

        public Tuple<List<AsetDto>, int> GetAllAset(PaginationQueryParam queryParam)
        {
            var asetQuery = _dbContext.Aset
                .Include(x => x.Kategori).AsQueryable();              ;
            if(queryParam.KategoriName != null)
            {
                asetQuery = asetQuery.Where(x => x.Kategori.Nama.Contains(queryParam.KategoriName));
            }
            asetQuery= asetQuery.Where(x => x.Nilai > 100000);
            int count = asetQuery.Count();
            var result = asetQuery.OrderBy(x => x.Nama).Skip(queryParam.Offset).Take(queryParam.Limit).ToList();
            return Tuple.Create(_mapper.Map<List<AsetDto>>(result), count);
        }

        public List<AsetGroupByKategori> GetAsetGroupingByKategori()
        {
            var aset = _dbContext.Aset.Include(x => x.Kategori).GroupBy(x => x.Kategori.Nama).Select(x => new AsetGroupByKategori()
            {
                KategoriName = x.Key,
                Assets = _mapper.Map<List<AsetDto>>(x.ToList()),
                TotalNilaiAset = x.Sum(y => y.Nilai)
            }).ToList();

            return aset;
        }

        public async Task<AsetDto?> GetById(Guid id)
        {
            var aset =  await _dbContext.Aset
                .Include(x => x.Kategori)                
                .FirstOrDefaultAsync(x => x.Id == id);
            if (aset == null) return null;
            return _mapper.Map<AsetDto>(aset);
        }

        public AsetDto UpdateAset(Guid id, AsetParamDto asetDtoParam)
        {
            var aset = _dbContext.Aset.Find(id);
            if(aset == null)
            {
                throw new Exception("Aset tidak ditemukan");
            }
            var kategori = _dbContext.Kategori.Find(asetDtoParam.KategoriId);
            if(kategori == null)
            {
                throw new Exception("Kategori tidak ditemukan");
            }
            aset.Nama = asetDtoParam.Nama;
            aset.KategoriId = asetDtoParam.KategoriId;
            aset.TanggalPerolehan = asetDtoParam.TanggalPerolehan;
            aset.Nilai = asetDtoParam.Nilai;
            _dbContext.Update(aset);
            _dbContext.SaveChanges();
            return _mapper.Map<AsetDto>(aset);
        }
        //1. Get All Aset
        //2. Get Aset By Id
        //3. Create Aset
        //4. Update Aset
        //5. Delete Aset

    }
}
