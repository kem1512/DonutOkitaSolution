using Microsoft.EntityFrameworkCore;

namespace Data.IRepositories
{
    public interface IDonutOkitaRepository<TEntity> where TEntity : class
    {
        Task<string?> Add(TEntity entity);

        Task<string?> Update(TEntity obj);

        Task<string?> Remove(TEntity obj);

        Task<IEnumerable<TEntity>> GetAll();
    }
}
