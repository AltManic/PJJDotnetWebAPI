namespace Day1WebApi.Models
{
    public class PaginationQueryParam
    {
        public int Limit { get; set; } = 5;
        public int Offset { get; set; } = 0;
        public string? KategoriName { get; set; }
    }
}
