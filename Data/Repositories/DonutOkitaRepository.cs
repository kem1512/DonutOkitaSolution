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
                Entity.Update(entity); await Context.SaveChangesAsync();
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
            return await Entity.AsNoTracking().ToListAsync();
        }

        public async Task<string?> Add(Dictionary<TEntity, TEntity> obj)
        {
            try
            {
                await Entity.AddRangeAsync(obj.Values);
                await Context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string?> Update(Dictionary<TEntity, TEntity> obj)
        {
            try
            {
                Entity.UpdateRange(obj.Values);
                await Context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public async Task<string?> Remove(Dictionary<TEntity, TEntity> obj)
        {
            try
            {
                //Entity.RemoveRange(x.Value);
                await Context.SaveChangesAsync();
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
