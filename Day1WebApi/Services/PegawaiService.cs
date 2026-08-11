using Day1WebApi.Data;

namespace Day1WebApi.Services
{
    public class PegawaiService
    {
        private readonly AppDbContext _appDbContext;

        public PegawaiService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Pegawai> GetAllPegawai()
        {

        }

        public Pegawai GetById(Guid id)
        {

        }

        public Pegawai CreatePegawai(PegawaiDto pegawaiParam)
        {
        }

        public Pegawai UpdatePegawai(Guid id, PegawaiDto pegawaiDto)
        {

        }

        public void DeletePegawai(Guid id)
        {

        }
    }
}
