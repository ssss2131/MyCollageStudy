using MyTodo.Shared;
using MyTodo.Shared.Dtos;
using MyTodo.Shared.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Service
{
    public interface ITodoService:IBaseService<TodoDto>
    {
        Task<ApiResponse<PagedList<TodoDto>>> GetAllFilterAsync(FilterQueryParameter parameter);

        Task<ApiResponse<SummaryDto>> GetSummary();
    }
}
