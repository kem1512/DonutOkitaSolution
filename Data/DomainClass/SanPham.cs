using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Data.DomainClass
{
    public class SanPham
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập mã")]
        public string? Ma { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập tên")]
        public string? Ten { get; set; }

        [JsonIgnore]
        public List<ChiTietSp>? ChiTietSps { get; set; }
    }
}
