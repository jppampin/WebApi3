namespace WebApi.Repositories 
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork {get; }
    }
}