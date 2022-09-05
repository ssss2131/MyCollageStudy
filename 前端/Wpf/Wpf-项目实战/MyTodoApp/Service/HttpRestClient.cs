using MyTodo.Shared;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
 

namespace MyTodoApp.Service
{
    public class HttpRestClient
    {
        private readonly string apiUrl;
        protected readonly RestClient client;
        public HttpRestClient(string apiUrl)
        {
            this.apiUrl = apiUrl;
            client = new RestClient();
        }

        public async Task<ApiResponse> ExecuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(new Uri(apiUrl + baseRequest.Route), baseRequest.Method);
            //request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Method == Method.Post)
            {
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                //" -H  "accept: text / plain" -H  "Content - Type: application / json"
                request.AddHeader("accept", "text/plain");
                request.AddHeader("language", "cn");
                request.AddHeader("Content-Type", "application/json");
            }
            else
            {
                request.AddHeader("Content-Type", baseRequest.ContentType);
            }
            if (baseRequest.Parameter != null)
                request.AddParameter("application/json", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
        }
        public async Task<ApiResponse<T>> ExecuteAsync<T>(BaseRequest baseRequest)
        {
            var request = new RestRequest(new Uri(apiUrl + baseRequest.Route), baseRequest.Method);
            if (baseRequest.Method==Method.Post)
            {
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                //" -H  "accept: text / plain" -H  "Content - Type: application / json"
                request.AddHeader("accept", "text/plain");
                request.AddHeader("language", "cn");
                request.AddHeader("Content-Type", "application/json");
            }
            else
            {
                request.AddHeader("Content-Type", baseRequest.ContentType);
            }

        
            if (baseRequest.Parameter != null)
                request.AddParameter("application/json", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
         
            var response = await client.ExecuteAsync(request);
          
            return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
        }
    }
}
