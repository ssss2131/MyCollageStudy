using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using System.Threading.Tasks;

namespace MyTodoApi.Service
{
    public interface ILoginService
    {
        Task<ApiResponse> LoginAsync(string Account,string Password);

        Task<ApiResponse> RegisterAsync(UserDto model);
    }
}
