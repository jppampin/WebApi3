using WebApi.Models;

namespace WebApi.Repositories.Generic
{
    public interface IUnitOfWork
    {
        IRepository<Order> OrderRepository { get; }
        
        void CommitAsync();

        void Reject();
    }
}