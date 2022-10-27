namespace Data.DomainClass
{
    public class GioHangChiTiet
    {
        public Guid IdGioHang { get; set; }

        public Guid IdChiTietSp { get; set; }

        public GioHang? GioHang { get; set; }

        public ChiTietSp? ChiTietSp { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }

        public decimal DonGiaKhiGiam { get; set; }
    }
}
