using System.Text.Json.Serialization;

namespace Day1WebApi.Models
{
    public class Kategori : BaseModel
    {
        public string Nama { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Aset> Aset { get; set; } = new List<Aset>();
    }
}
