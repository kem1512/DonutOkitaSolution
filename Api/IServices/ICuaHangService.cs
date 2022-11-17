using Data.DomainClass;

namespace Api.IServices
{
    public interface ICuaHangService
    {
        Task<IEnumerable<CuaHang>> GetAll();

        Task<string?> Add(CuaHang ch);

        Task<string?> Update(CuaHang ch);

        Task<string?> Remove(CuaHang ch);

        Task<CuaHang?> GetById(Guid Id);
    }
}
