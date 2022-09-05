using MyTodo.Shared;
using MyTodo.Shared.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodoApp.Service
{
    public class BaseService<TEntitiy> : IBaseService<TEntitiy> where TEntitiy : class
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public BaseService(HttpRestClient client,string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }
        public async Task<ApiResponse<TEntitiy>> AddAsync(TEntitiy entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Post{serviceName}";
            request.Parameter = entity;
            return await client.ExecuteAsync<TEntitiy>(request);          
        }

        public async Task<ApiResponse<TEntitiy>> DeleteAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Delete;
            request.Route = $"api/{serviceName}/Delete{serviceName}?id={id}"; 
            return await client.ExecuteAsync<TEntitiy>(request);
 
        }

        public async Task<ApiResponse<PagedList<TEntitiy>>> GetAllAsync(QueryParameter queryParameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/GetAll?PageIndex={queryParameter.PageIndex}&PageSize={queryParameter.PageSize}&Search={queryParameter.Search}";
           
            return await client.ExecuteAsync<PagedList<TEntitiy>>(request);
  
        }

        public async Task<ApiResponse<TEntitiy>> GetFirstOfDefaultAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Get;
            request.Route = $"api/{serviceName}/Get?id={id}"; 
            return await client.ExecuteAsync<TEntitiy>(request);
        }

        public async Task<ApiResponse<TEntitiy>> UpdateAsync(TEntitiy entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = RestSharp.Method.Post;
            request.Route = $"api/{serviceName}/Put{serviceName}";
            request.Parameter = entity; 
            return await client.ExecuteAsync<TEntitiy>(request);
        }
    }
}
