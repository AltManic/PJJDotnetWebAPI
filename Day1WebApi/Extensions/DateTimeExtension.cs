namespace Day1WebApi.Extensions
{
    public static class DateTimeExtension
    {
        //01/01/2024 -> 1 Januari 2024
        public static string ToIndonesiaFormat(this DateOnly date)
        {
            var bulan = new List<string>
            {
                "Januari", "Februari", "Maret", "April", "Mei", "Juni",
                "Juli", "Agustus", "September", "Oktober", "November", "Desember"
            };
            return $"{date.Day} {bulan[date.Month - 1]} {date.Year}";
        }
    }
}
