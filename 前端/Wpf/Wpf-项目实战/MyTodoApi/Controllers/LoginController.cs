 
using Microsoft.AspNetCore.Mvc;
using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodoApi.Service;
using System.Threading.Tasks;

namespace MyTodoApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService service;

        public LoginController(ILoginService service)
        {
            this.service = service;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse> LoginAsync([FromBody] UserDto model) => await service.LoginAsync(model.Account, model.PassWord);
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ApiResponse> Register([FromBody]UserDto model) => await service.RegisterAsync(model);
    }
}
