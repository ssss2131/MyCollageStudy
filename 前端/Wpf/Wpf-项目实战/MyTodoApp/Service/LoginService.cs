using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpRestClient client;
        private readonly string serviceName = "Login";

        public LoginService(HttpRestClient client)
        {
            this.client = client;
         
        }
        public async Task<ApiResponse<RegisterUserDto>> LoginAsync(UserDto model)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Login";
            request.Parameter = model;
            return await client.ExecuteAsync<RegisterUserDto>(request);
          
        }

        public async Task<ApiResponse<RegisterUserDto>> RegisterAsync(UserDto model)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Register";
            request.Parameter = model;
            return await client.ExecuteAsync<RegisterUserDto>(request);
        }
    }
}
