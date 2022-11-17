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

        public async Task<string?> Add(TEntity entity)
        {
            try
            {
                await Entity.AddAsync(entity); 
                await Context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string?> Update(TEntity entity)
        {
            try
            {
                Context.Entry(entity).State = EntityState.Modified; Entity.Update(entity); await Context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string?> Remove(TEntity entity)
        {
            try
            {
                Entity.Remove(entity); await Context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Entity.ToListAsync();
        }
    }
}
