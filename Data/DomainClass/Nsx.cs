using Newtonsoft.Json;

namespace Data.DomainClass
{
    public class Nsx
    {
        public Guid Id { get; set; }

        public string? Ma { get; set; }

        public string? Ten { get; set; }

        [JsonIgnore]
        public List<ChiTietSp>? ChiTietSps { get; set; }
    }
}
