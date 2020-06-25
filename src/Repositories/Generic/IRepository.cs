using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repositories.Generic
{
    public interface IRepository<T>
    {
        IQueryable<T> Entities { get; }
        Task<List<T>> ReadOnlyAsyncEntries { get; }
        void Add(T entity);

        void Update(T entity);
        void Remove(T entity);
    }
}