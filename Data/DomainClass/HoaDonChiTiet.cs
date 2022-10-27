using Newtonsoft.Json;

namespace Data.DomainClass
{
    public class HoaDonChiTiet
    {
        public Guid IdHoaDon { get; set; }

        public Guid IdChiTietSp { get; set; }

        [JsonIgnore]
        public HoaDon? HoaDon { get; set; }

        [JsonIgnore]
        public ChiTietSp? ChiTietSp { get; set; }

        public int SoLuong { get; set; }

        public decimal DonGia { get; set; }
    }
}
