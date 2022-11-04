using Data.DomainClass;

namespace Api.IServices
{
    public interface IMauSacService
    {
        Task<IEnumerable<MauSac>> GetAll();

        Task<bool> Add(MauSac ms);

        Task<bool> Update(MauSac ms);

        Task<bool> Remove(MauSac ms);

        Task<MauSac?> GetById(Guid Id);
    }
}
