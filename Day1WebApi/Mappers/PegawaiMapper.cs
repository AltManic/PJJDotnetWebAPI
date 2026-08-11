using AutoMapper;

namespace Day1WebApi.Mappers
{
    public class PegawaiMapper : Profile
    {
        public PegawaiMapper()
        {
            CreateMap<Models.Pegawai, Dto.PegawaiDto>();
            CreateMap<Dto.PegawaiDto, Models.Pegawai>();

            CreateMap<AsetDto, Aset>();
            CreateMap<Aset, AsetDto>();
        }
    }
}
