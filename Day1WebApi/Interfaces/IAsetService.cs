namespace Day1WebApi.Interfaces
{
    public interface IAsetService
    {
        List<AsetDto> GetAllAset();
        Task<AsetDto?> GetById(Guid id);
        AsetDto CreateAset(AsetParamDto asetParam);
        AsetDto UpdateAset(Guid id, AsetParamDto asetDtoParam);
        void DeleteAset(Guid id);
    }
}
