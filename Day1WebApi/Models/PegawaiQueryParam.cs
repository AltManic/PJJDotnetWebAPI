namespace Day1WebApi.Models
{
    public class PegawaiQueryParam : PaginationQueryParam
    {
        public string? Nama { get; set; }
        public string? Nip { get; set; }
    }
}
