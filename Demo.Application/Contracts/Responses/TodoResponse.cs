using Demo.Domain.Enums;
using System;

namespace Demo.Application.Contracts.Responses
{
    public class TodoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TodoStatus Status { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}