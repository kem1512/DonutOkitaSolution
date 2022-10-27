using Data.DomainClass;

namespace Api.IServices
{
    public interface IDongSpService
    {
        Task<IEnumerable<DongSp>> GetAll();

        Task<bool> Add(DongSp dsp);

        Task<bool> Update(DongSp dsp);

        Task<bool> Remove(DongSp dsp);

        Task<DongSp?> GetByProperties<T>(T val);
    }
}
