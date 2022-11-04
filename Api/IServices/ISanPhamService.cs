using Data.ViewModels;
using Data.DomainClass;

namespace Api.IServices
{
    public interface ISanPhamService
    {
        Task<IEnumerable<SanPham>> GetAll();

        Task<bool> Add(SanPham sp);

        Task<bool> Update(SanPham sp);

        Task<bool> Remove(SanPham sp);

        Task<SanPham?> GetById(Guid Id);
    }
}
