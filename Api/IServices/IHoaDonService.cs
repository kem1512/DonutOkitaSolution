using Data.ViewModels;
using Data.DomainClass;

namespace Api.IServices
{
    public interface IHoaDonService
    {
        Task<IEnumerable<HoaDon>> GetAll();

        Task<bool> Add(HoaDon ctsp);

        Task<bool> Update(HoaDon ctsp);

        Task<bool> Remove(HoaDon ctsp);

        Task<HoaDon?> GetByProperties<T>(T val);
    }
}
