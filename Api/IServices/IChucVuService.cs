using Data.DomainClass;

namespace Api.IServices
{
    public interface IChucVuService
    {
        Task<IEnumerable<ChucVu>> GetAll();

        Task<bool> Add(ChucVu cv);

        Task<bool> Update(ChucVu cv);

        Task<bool> Remove(ChucVu cv);

        Task<ChucVu?> GetByProperties<T>(T val);
    }
}
