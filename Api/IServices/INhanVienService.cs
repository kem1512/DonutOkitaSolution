using Data.DomainClass;

namespace Api.IServices
{
    public interface INhanVienService
    {
        Task<IEnumerable<NhanVien>> GetAll();

        Task<bool> Add(NhanVien nv);

        Task<bool> Update(NhanVien nv);

        Task<bool> Remove(NhanVien nv);

        Task<NhanVien?> GetByProperties<T>(T val);
    }
}
