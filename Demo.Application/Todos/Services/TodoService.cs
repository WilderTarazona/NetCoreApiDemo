using AutoMapper;
using Demo.Application.Contracts.Responses;
using Demo.Application.Interfaces.Repositories;
using Demo.Application.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Application.Todos.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TodoResponse>> ListAsync()
        {
            var result = await _unitOfWork.Todos.GetAll();
            return _mapper.Map<List<TodoResponse>>(result.ToList());
        }
    }
}