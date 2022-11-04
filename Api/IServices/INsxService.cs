using Data.DomainClass;

namespace Api.IServices
{
    public interface INsxService
    {
        Task<IEnumerable<Nsx>> GetAll();

        Task<bool> Add(Nsx nsx);

        Task<bool> Update(Nsx nsx);

        Task<bool> Remove(Nsx nsx);

        Task<Nsx?> GetById(Guid Id);
    }
}
