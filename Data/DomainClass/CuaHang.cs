using System.ComponentModel.DataAnnotations;

namespace Data.DomainClass
{
    public class CuaHang
    {
        public Guid Id { get; set; }

        public string? Ma { get; set; }

        public string? Ten { get; set; }

        public string? DiaChi { get; set; }

        public string? ThanhPho { get; set; }

        public string? QuocGia { get; set; }

        public List<NhanVien>? NhanViens { get; set; }
    }
}
