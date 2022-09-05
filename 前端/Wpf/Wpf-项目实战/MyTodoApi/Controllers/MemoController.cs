using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApi.Service;
using System.Threading.Tasks;

namespace MyTodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService service;

        public MemoController(IMemoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await service.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery]QueryParameter parameter) => await service.GetAllAsync(parameter);

        [HttpPost]
        public async Task<ApiResponse> PostMemo([FromBody] MemoDto model) => await service.AddAsync(model);

        [HttpDelete]
        public async Task<ApiResponse> DeleteMemo(int id) => await service.DeleteAsync(id);

        [HttpPost]
        public async Task<ApiResponse> PutMemo([FromBody] MemoDto model) => await service.UpdateAsync(model);
    }
}
