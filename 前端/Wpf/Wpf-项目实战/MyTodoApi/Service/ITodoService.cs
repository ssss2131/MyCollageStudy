using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using MyTodoApi.Context;
using System.Threading.Tasks;

namespace MyTodoApi.Service
{
    public interface ITodoService : IBaseService<TodoDto>
    {
        Task<ApiResponse> GetAllAsync(FilterQueryParameter parameter);
        Task<ApiResponse> Summary();
    }
}
