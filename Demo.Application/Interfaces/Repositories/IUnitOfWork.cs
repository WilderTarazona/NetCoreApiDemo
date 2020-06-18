namespace Demo.Application.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        ITodoRepository Todos { get; }
    }
}