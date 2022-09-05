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
    public class TodoService : BaseService<TodoDto>, ITodoService
    {
        private readonly HttpRestClient client;

        public TodoService(HttpRestClient client) : base(client, "Todo")
        {
            this.client = client;
        }

        public async Task<ApiResponse<PagedList<TodoDto>>> GetAllFilterAsync(FilterQueryParameter parameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/Todo/GetAll?PageIndex={parameter.PageIndex}&PageSize={parameter.PageSize}&Search={parameter.Search}&Status={parameter.Status}";

            return await client.ExecuteAsync<PagedList<TodoDto>>(request);
        }

        public async Task<ApiResponse<SummaryDto>> GetSummary()
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/Todo/GetSummary";

            return await client.ExecuteAsync<SummaryDto>(request);
        }
    }
}
