using AutoMapper;

namespace Day1WebApi.Mappers
{
    public class AsetMapper : Profile
    {
        public AsetMapper()
        {
            CreateMap<AsetDto, Aset>();
            CreateMap<Aset, AsetDto>();
        }
    }
}
