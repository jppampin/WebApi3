using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private readonly ApiDbContext apiDbContext;

        private DbSet<T> dbSet => apiDbContext.Set<T>();
        public IQueryable<T> Entities => dbSet;

        public Task<List<T>> ReadOnlyAsyncEntries => dbSet.AsNoTracking().ToListAsync();

        public GenericRepository(ApiDbContext context)
        {
            apiDbContext = context;
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }
    }
}