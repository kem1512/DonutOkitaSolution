using Data.ViewModels;
using Data.DomainClass;

namespace Api.IServices
{
    public interface ISanPhamService
    {
        Task<IEnumerable<SanPham>> GetAll();

        Task<string?> Add(SanPham sp);

        Task<string?> Update(SanPham sp);

        Task<string?> Remove(SanPham sp);

        Task<SanPham?> GetById(Guid Id);
    }
}
