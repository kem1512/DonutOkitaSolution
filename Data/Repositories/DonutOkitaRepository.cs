using Data.IRepositories;
using Data.DomainClass;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories
{
    public class DonutOkitaRepository<TEntity> : IDonutOkitaRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> Entity { get; set; }
        private DbContext Context { get; set; }

        public DonutOkitaRepository(DbContext context)
        {
            Context = context; Entity = context.Set<TEntity>();
        }

        public async Task<bool> Add(TEntity entity)
        {
            try
            {
                await Entity.AddAsync(entity); 
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified; Entity.Update(entity); await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Remove(TEntity entity)
        {
            try
            {
                Entity.Remove(entity); await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }
    }
}
