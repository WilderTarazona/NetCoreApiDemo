using Dapper;
using Demo.Application.Interfaces.Repositories;
using Demo.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IConfiguration _configuration;

        public TodoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Todo>> GetAll()
        {
            var sql = "SELECT * FROM Todo;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Todo>(sql);
                return result;
            }
        }
        public async Task<Todo> Get(int id)
        {
            var sql = "SELECT * FROM Todo WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Todo>(sql, new { Id = id });
                return result.SingleOrDefault();
            }
        }
        public async Task<int> Add(Todo entity)
        {
            entity.DateCreated = DateTime.Now;
            var sql = "INSERT INTO Todo (Name, Description, Status, DueDate, DateCreated) Values (@Name, @Description, @Status, @DueDate, @DateCreated);";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
        public async Task<int> Update(Todo entity)
        {
            entity.DateModified = DateTime.Now;
            var sql = "UPDATE Todo SET Name = @Name, Description = @Description, Status = @Status, DueDate = @DueDate, DateModified = @DateModified WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, entity);
                return affectedRows;
            }
        }
        public async Task<int> Delete(int id)
        {
            var sql = "DELETE FROM Todo WHERE Id = @Id;";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var affectedRows = await connection.ExecuteAsync(sql, new { Id = id });
                return affectedRows;
            }
        }
    }
}