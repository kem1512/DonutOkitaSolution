using Data.DomainClass;

namespace Api.IServices
{
    public interface INhanVienService
    {
        Task<IEnumerable<NhanVien>> GetAll();

        Task<string?> Add(NhanVien nv);

        Task<string?> Update(NhanVien nv);

        Task<string?> Remove(NhanVien nv);

        Task<NhanVien?> GetById(Guid Id);
    }
}
