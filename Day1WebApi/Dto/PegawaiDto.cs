using System.ComponentModel.DataAnnotations;

namespace Day1WebApi.Dto
{
    public class PegawaiDto
    {
        public Guid? Id { get; set; }
        public string? Nama { get; set; }
        public string? NIP { get; set; }
        public string? Jabatan { get; set; }
        [Range(0, long.MaxValue, ErrorMessage = "Gaji harus lebih besar dari 0")]
        public long? Gaji { get; set; }
        public DateOnly? TanggalMasuk { get; set; }
        public string TanggalMasukFormatIndo { get { return TanggalMasuk == null ? "" :TanggalMasuk.Value.ToIndonesiaFormat(); } }
    }
}
