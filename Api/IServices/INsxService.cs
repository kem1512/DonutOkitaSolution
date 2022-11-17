using Data.DomainClass;

namespace Api.IServices
{
    public interface INsxService
    {
        Task<IEnumerable<Nsx>> GetAll();

        Task<string?> Add(Nsx nsx);

        Task<string?> Update(Nsx nsx);

        Task<string?> Remove(Nsx nsx);

        Task<Nsx?> GetById(Guid Id);
    }
}
