namespace Day1WebApi.Models
{
    public class Pegawai : BaseIdentityModel
    {
        public string Nama { get; set; }
        public string NIP { get; set; }
        public string Jabatan { get; set; }
        public long Gaji { get; set; }
        public DateOnly TanggalMasuk { get; set; }
    }
}
