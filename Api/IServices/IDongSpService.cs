using Data.DomainClass;

namespace Api.IServices
{
    public interface IDongSpService
    {
        Task<IEnumerable<DongSp>> GetAll();

        Task<string?> Add(DongSp dsp);

        Task<string?> Update(DongSp dsp);

        Task<string?> Remove(DongSp dsp);

        Task<DongSp?> GetById(Guid Id);
    }
}
