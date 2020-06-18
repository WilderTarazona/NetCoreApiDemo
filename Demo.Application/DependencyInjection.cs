using AutoMapper;
using Demo.Application.Interfaces.Services;
using Demo.Application.Todos.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Demo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITodoService, TodoService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            // aqui falta agregar el filter validator
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}