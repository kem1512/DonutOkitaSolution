using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Data.DomainClass
{
    public class DongSp
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập mã")]
        public string? Ma { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập tên dòng sản phẩm")]
        public string? Ten { get; set; }

        [JsonIgnore]
        public List<ChiTietSp>? ChiTietSps { get; set; }
    }
}
