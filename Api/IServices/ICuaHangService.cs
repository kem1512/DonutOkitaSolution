using Data.DomainClass;

namespace Api.IServices
{
    public interface ICuaHangService
    {
        Task<IEnumerable<CuaHang>> GetAll();

        Task<bool> Add(CuaHang ch);

        Task<bool> Update(CuaHang ch);

        Task<bool> Remove(CuaHang ch);

        Task<CuaHang?> GetById(Guid Id);
    }
}
