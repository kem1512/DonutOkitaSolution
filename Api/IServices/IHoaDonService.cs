using Data.ViewModels;
using Data.DomainClass;

namespace Api.IServices
{
    public interface IHoaDonService
    {
        Task<IEnumerable<HoaDon>> GetAll();

        Task<string?> Add(HoaDon ctsp);

        Task<string?> Update(HoaDon ctsp);

        Task<string?> Remove(HoaDon ctsp);

        Task<HoaDon?> GetById(Guid Id);
    }
}
