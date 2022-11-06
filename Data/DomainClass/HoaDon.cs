using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Data.DomainClass
{
    public class HoaDon
    {
        public Guid Id { get; set; }

        public string? Ma { get; set; }

        public DateTime NgayTao { get; set; }

        public DateTime? NgayThanhToan { get; set; }

        public DateTime? NgayShip { get; set; }

        public DateTime? NgayNhan { get; set; }

        public int TinhTrang { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập tên")]
        public string? TenNguoiNhan { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string? DiaChi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string? Sdt { get; set; }

        public Guid? IdKh { get; set; }

        public Guid? IdNv { get; set; }

        [JsonIgnore]
        public KhachHang? KhachHang { get; set; }

        [JsonIgnore]
        public NhanVien? NhanVien { get; set; }

        [JsonIgnore]
        public List<HoaDonChiTiet>? HoaDonChiTiets { get; set; }
    }
}
