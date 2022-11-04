using Microsoft.EntityFrameworkCore;

namespace Data.IRepositories
{
    public interface IDonutOkitaRepository<TEntity> where TEntity : class
    {
        Task<bool> Add(TEntity entity);

        Task<bool> Update(TEntity obj);

        Task<bool> Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
