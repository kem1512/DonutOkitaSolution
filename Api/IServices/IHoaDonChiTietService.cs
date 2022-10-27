using Data.DomainClass;

namespace Api.IServices
{
    public interface IHoaDonChiTietService
    {
        Task<IEnumerable<HoaDonChiTiet>> GetAll();

        Task<bool> Add(HoaDonChiTiet hdct);

        Task<bool> Update(HoaDonChiTiet hdct);

        Task<bool> Remove(HoaDonChiTiet hdct);

        Task<HoaDonChiTiet?> GetByProperties<T>(T val);
    }
}
