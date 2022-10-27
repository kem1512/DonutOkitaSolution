using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Data.DomainClass
{
    public class MauSac
    {
        public Guid Id { get; set; }

        public string? Ma { get; set; }

        public string? Ten { get; set; }
        [JsonIgnore]
        public List<ChiTietSp>? ChiTietSps { get; set; }
    }
}
