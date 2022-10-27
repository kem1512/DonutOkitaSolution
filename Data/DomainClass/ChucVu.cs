using System.ComponentModel.DataAnnotations;

namespace Data.DomainClass
{
    public class ChucVu
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập mã")]
        public string? Ma { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Bạn chưa nhập tên chức vụ")]
        public string? Ten { get; set; }

        public List<NhanVien>? NhanViens { get; set; }
    }
}
