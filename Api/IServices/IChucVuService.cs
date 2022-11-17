using Data.DomainClass;

namespace Api.IServices
{
    public interface IChucVuService
    {
        Task<IEnumerable<ChucVu>> GetAll();

        Task<string?> Add(ChucVu cv);

        Task<string?> Update(ChucVu cv);

        Task<string?> Remove(ChucVu cv);

        Task<ChucVu?> GetById(Guid Id);
    }
}
