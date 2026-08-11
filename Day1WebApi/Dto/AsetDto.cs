using System.ComponentModel.DataAnnotations;

namespace Day1WebApi.Dto
{
    public class AsetDto
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string? Nama { get; set; }
        public DateOnly TanggalPerolehan { get; set; }
        public Guid KategoriId { get; set; }
        [Range(1, int.MaxValue)]
        public int Nilai { get; set; }
        public KategoriDto Kategori { get; set; }
    }

    public class AsetParamDto
    {
        [Required]
        [MaxLength(20)]
        public string? Nama { get; set; }
        public DateOnly TanggalPerolehan { get; set; }
        public Guid KategoriId { get; set; }
        [Range(1, int.MaxValue)]
        public int Nilai { get; set; }
    }
}
