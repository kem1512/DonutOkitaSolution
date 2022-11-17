using Data.DomainClass;

namespace Api.IServices
{
    public interface IChiTietSpService
    {
        Task<IEnumerable<ChiTietSp>> GetAll();

        Task<string?> Add(ChiTietSp ctsp);

        Task<string?> Update(ChiTietSp ctsp);

        Task<string?> Remove(ChiTietSp ctsp);

        Task<ChiTietSp?> GetById(Guid Id);
    }
}
