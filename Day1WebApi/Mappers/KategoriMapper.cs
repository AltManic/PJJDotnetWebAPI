using AutoMapper;

namespace Day1WebApi.Mappers
{
    public class KategoriMapper : Profile
    {
        public KategoriMapper()
        {
            CreateMap<KategoriDto, Kategori>();
            CreateMap<Kategori, KategoriDto>();
        }
    }
}
