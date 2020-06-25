using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Repositories.Generic
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext dbContext;
        
        public IRepository<Order> OrderRepository => new GenericRepository<Order>(dbContext);

        public UnitOfWork(ApiDbContext context)
        {
            dbContext = context;
        }

        public void CommitAsync()
        {
            dbContext.SaveChangesAsync();
        }

        public void Reject()
        {
             var changedEntriesCopy = dbContext.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }
    }

}