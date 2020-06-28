using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly ApiDbContext apiDbContext;

        private DbSet<T> dbSet => apiDbContext.Set<T>();

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

        public async Task<List<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await dbSet.Where(e => e.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}