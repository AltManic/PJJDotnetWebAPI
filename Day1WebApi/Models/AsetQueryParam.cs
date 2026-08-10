namespace Day1WebApi.Models
{
    public class AsetQueryParam
    {
        /// <summary>
        /// Filter berdasarkan nama aset
        /// </summary>
        public string? Nama { get; set; }
        public string? Kategori { get; set; }
        /// <summary>
        /// Filter berdasarkan tahun perolehan
        /// </summary>
        public int? Tahun { get; set; }
    }
}
