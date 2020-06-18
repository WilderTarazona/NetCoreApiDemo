using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Application.Contracts.Responses;
using Demo.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<TodoResponse>>> GetAll()
        {
            var post = await _todoService.ListAsync();
            return post.ToList();
        }

        //[HttpGet("{id}")]
        //public async Task<ActionResult<TaskDto>> Get(int id)
        //{
        //    return await Mediator.Send(new GetTaskByIdQuery { Id = id });
        //}

        //[HttpPost]
        //public async Task<ActionResult<int>> Create(CreateTaskCommand command)
        //{
        //    Response.StatusCode = 201;
        //    return await Mediator.Send(command);
        //}

        //[HttpPut]
        //public async Task<ActionResult<int>> Update(UpdateTaskCommand command)
        //{
        //    return await Mediator.Send(command);
        //}

        //[HttpDelete]
        //public async Task<ActionResult<int>> Delete(int id)
        //{
        //    return await Mediator.Send(new DeleteTaskCommand { Id = id });
        //}
    }
}