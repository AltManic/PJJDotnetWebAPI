namespace Day1WebApi.Data
{
    public class PaginationResponse<T>
    {
        public int Total { get; set; }
        public List<T> Items { get; set; }
    }
}
