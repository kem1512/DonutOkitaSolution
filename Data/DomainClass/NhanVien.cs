using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.DomainClass
{
    public class NhanVien
    {

        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập mã")]
        public string? Ma { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập tên")]
        public string? Ten { get; set; }

        public string? TenDem { get; set; }

        public string? Ho { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập giới tính")]
        public string? GioiTinh { get; set; }

        public DateTime? NgaySinh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa địa chỉ")]
        public string? DiaChi { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập số điện thoại")]
        public string? Sdt { get; set; }

        public string? MatKhau { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập chọn cửa hàng")]
        public Guid? IdCh { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa chọn chức vụ")]
        public Guid? IdCv { get; set; }

        public Guid? IdGuiBc { get; set; }

        public CuaHang? CuaHang { get; set; }

        public ChucVu? ChucVu { get; set; }

        public NhanVien? Nhan_Vien { get; set; }

        public int TrangThai { get; set; }

        public List<HoaDon>? HoaDons { get; set; }

        public List<NhanVien>? NhanViens { get; set; }

        public List<GioHang>? GioHangs { get; set; }
    }
}
