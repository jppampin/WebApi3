using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Repositories 
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(CancellationToken token = default(CancellationToken));
        Task<bool> SaveEntitiesAsync(CancellationToken token = default(CancellationToken)); 
    }

}