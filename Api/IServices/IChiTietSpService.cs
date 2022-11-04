using Data.DomainClass;

namespace Api.IServices
{
    public interface IChiTietSpService
    {
        Task<IEnumerable<ChiTietSp>> GetAll();

        Task<bool> Add(ChiTietSp ctsp);

        Task<bool> Update(ChiTietSp ctsp);

        Task<bool> Remove(ChiTietSp ctsp);

        Task<ChiTietSp?> GetById(Guid Id);
    }
}
