using Demo.Application.Interfaces.Repositories;
using Demo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}