using Demo.Application.Interfaces.Repositories;

namespace Demo.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ITodoRepository todoRepository)
        {
            Todos = todoRepository;
        }
        public ITodoRepository Todos { get; }
    }
}