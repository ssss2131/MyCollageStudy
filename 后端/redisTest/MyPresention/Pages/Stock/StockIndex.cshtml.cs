using ApiResource.Model;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;
using System;
using System.Text;
using System.Text.Json;

namespace MyPresention.Pages.Stock
{
    public class StockIndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StockIndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;

           
        }

        [BindProperty]
        public List<StockViewModel> models { get; set; } 

       
      
        public async Task OnGet()
        {
            var response = await _httpClientFactory.CreateClient().GetAsync("https://localhost:7130/api/Stock/Index");

            if (response != null)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                List<StockViewModel> stocks = JsonSerializer.Deserialize<List<StockViewModel>>(result); 
                this.models = stocks;              
            }
           
        }
        
        public async Task OnPost(int stockId, int number)
        {

            //var value = new Dictionary<string, string> {
            //    { "stockId",stockId.ToString()},
            //    { "number",number.ToString()}
            //};
            #region ʹ��restSharp
            var client = new RestClient("https://localhost:7130");

            var request = new RestRequest($"api/Stock/PurchaseBookInStock?stockId=1&&number={number.ToString()}", Method.Post);
            //request.AddParameter("number", "10"); // ���Ӳ����� URL querystring

            #endregion
            var r =  await client.ExecuteAsync(request);

            //var Content = new FormUrlEncodedContent(value);
            //var data = new StringContent("1", Encoding.UTF8, "application/json");
            //var response = await _httpClientFactory.CreateClient().PostAsync("https://localhost:7130/api/Stock/PurchaseBookInStock", Content);
       

            //var response2  = await _httpClientFactory.CreateClient().PostAsync("https://localhost:7130/api/Stock/PurchaseBookInStock", data);
            //var responseString = await "https://localhost:7130/api/Stock/Test"
            //    .PostStringAsync(stockId.ToString());
            //.PostUrlEncodedAsync(new { stockId = stockId.ToString() })
            //.ReceiveString();

            
          

        }
        
    }
}
