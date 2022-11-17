using Data.DomainClass;

namespace Api.IServices
{
    public interface IMauSacService
    {
        Task<IEnumerable<MauSac>> GetAll();

        Task<string?> Add(MauSac ms);

        Task<string?> Update(MauSac ms);

        Task<string?> Remove(MauSac ms);

        Task<MauSac?> GetById(Guid Id);
    }
}
