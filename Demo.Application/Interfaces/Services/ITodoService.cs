using Demo.Application.Contracts.Responses;
using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Interfaces.Services
{
    public interface ITodoService
    {
        Task<List<TodoResponse>> ListAsync();
        //Task<TodoResponse> SaveAsync(Product product);
        //Task<TodoResponse> UpdateAsync(int id, Product product);
        //Task<TodoResponse> DeleteAsync(int id);
    }
}