using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
using Demo.Application.Contracts.Responses;
using Demo.Application.Contracts;
using Demo.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Demo.API.Controllers.V1
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private ProducerConfig _config;

        public TodoController(ITodoService todoService, ProducerConfig config)
        {
            _todoService = todoService;
            _config = config;
        }
        [HttpGet(ApiRoutes.Todos.GetAll)]
        public async Task<ActionResult<List<TodoResponse>>> GetAll()
        {
            var post = await _todoService.ListAsync();
            return post.ToList();
        }
        [HttpGet(ApiRoutes.Todos.Send)]
        public async Task<ActionResult> Get([FromBody] TodoResponse todo)
        {
            try
            {
                string serializedTodo = JsonConvert.SerializeObject(todo);
                using (var producer = new ProducerBuilder<Null, string>(_config).Build())
                {
                    await producer.ProduceAsync("temp-topic-two", new Message<Null, string> { Value = serializedTodo });
                    producer.Flush(TimeSpan.FromSeconds(10));
                    return Ok(true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //[HttpGet("{id:int:min(1)}")]
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