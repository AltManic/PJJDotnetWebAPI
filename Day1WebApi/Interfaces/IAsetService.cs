namespace Day1WebApi.Interfaces
{
    public interface IAsetService
    {
        Tuple<List<AsetDto>, int> GetAllAset(PaginationQueryParam queryParam);
        Task<AsetDto?> GetById(Guid id);
        AsetDto CreateAset(AsetParamDto asetParam);
        AsetDto UpdateAset(Guid id, AsetParamDto asetDtoParam);
        void DeleteAset(Guid id);
        Dictionary<string, List<AsetDto>> GetAsetGroupingByKategori();
    }
}
