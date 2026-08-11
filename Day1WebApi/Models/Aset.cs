using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day1WebApi.Models
{
    public class Aset : BaseModel
    {
        public string Nama { get; set; } = string.Empty;
        public DateOnly TanggalPerolehan { get; set; }
        public Guid KategoriId { get; set; }
        public int Nilai { get; set; }

        public string? FotoPath { get; set; }

        public  Kategori Kategori{ get; set; }
    }
}
