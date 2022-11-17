using Data.DomainClass;

namespace Api.IServices
{
    public interface IHoaDonChiTietService
    {
        Task<IEnumerable<HoaDonChiTiet>> GetAll();

        Task<string?> Add(HoaDonChiTiet hdct);

        Task<string?> Update(HoaDonChiTiet hdct);

        Task<string?> Remove(HoaDonChiTiet hdct);

        Task<HoaDonChiTiet?> GetById(Guid Id);
    }
}
