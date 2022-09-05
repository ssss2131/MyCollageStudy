using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApi.Context;
using MyTodoApi.Service;
using System.Threading.Tasks;

namespace MyTodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ITodoService service;

        public ToDoController(ITodoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);
        [HttpGet]
        public async Task<ApiResponse> GetSummary() => await service.Summary();

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] FilterQueryParameter parameter) => await service.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> PostTodo([FromBody] TodoDto model) => await service.AddAsync(model);
                
        [HttpDelete]
        public async Task<ApiResponse> DeleteTodo(int id) => await service.DeleteAsync(id);

        [HttpPost]
        public async Task<ApiResponse> PutTodo([FromBody] TodoDto model) => await service.UpdateAsync(model);

    }
}
