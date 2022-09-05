using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Service
{
    public interface ILoginService
    {
        Task<ApiResponse<RegisterUserDto>> LoginAsync(UserDto model);

        Task<ApiResponse<RegisterUserDto>> RegisterAsync(UserDto model);
    }
}
