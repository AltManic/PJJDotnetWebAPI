namespace Day1WebApi.Dto
{
    public class PegawaiDto
    {
        public Guid Id { get; set; }
        public string Nama { get; set; }
        public string NIP { get; set; }
        public string Jabatan { get; set; }
        public long Gaji { get; set; }
        public DateOnly TanggalMasuk { get; set; }
    }
}
