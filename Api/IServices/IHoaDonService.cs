using Data.ViewModels;
using Data.DomainClass;

namespace Api.IServices
{
    public interface IHoaDonService
    {
        Task<IEnumerable<HoaDon>> GetAll();

        Task<string?> Add(HoaDon hd);

        Task<string?> Update(HoaDon hd);

        Task<string?> Remove(HoaDon hd);

        Task<HoaDon?> GetById(Guid Id);
    }
}
