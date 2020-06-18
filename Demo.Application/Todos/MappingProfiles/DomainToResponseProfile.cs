using AutoMapper;
using Demo.Application.Contracts.Responses;
using Demo.Domain.Entities;

namespace Demo.Application.Todos.MappingProfiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Todo, TodoResponse>();
        }
    }
}