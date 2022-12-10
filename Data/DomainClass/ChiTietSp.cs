using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Data.DomainClass
{
    public class ChiTietSp
    {
        public Guid Id { get; set; }

        public int NamBh { get; set; }

        public string? MoTa { get; set; }

        public int SoLuongTon { get; set; }

        public decimal GiaNhap { get; set; }

        public decimal GiaBan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Thêm đường dẫn ảnh vào bạn ơi")]
        [Url(ErrorMessage = "Sai đường dẫn rồi bạn ơi")]
        public string? Anh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn sản phẩm")]
        public Guid? IdSp { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn nhà sản xuất")]
        public Guid? IdNsx { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn màu sắc")]
        public Guid? IdMauSac { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn dòng sản phẩm")]
        public Guid? IdDongSp { get; set; }

        [JsonIgnore]
        public SanPham? SanPham { get; set; }

        [JsonIgnore]
        public Nsx? Nsx { get; set; }

        [JsonIgnore]
        public MauSac? MauSac { get; set; }

        [JsonIgnore]
        public DongSp? DongSp { get; set; }

        [JsonIgnore]
        public List<GioHangChiTiet>? GioHangChiTiets { get; set; }

        [JsonIgnore]
        public List<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
    }
}
