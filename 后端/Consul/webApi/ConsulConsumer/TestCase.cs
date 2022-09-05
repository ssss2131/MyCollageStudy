using System.Net.Http;
using System.Net;
using Consul;
namespace ConsulConsumer;
public interface IService
{
    Task<string> InvokeService();
}
public class ServiceImp:IService
{
    // private readonly IHttpClientFactory _fac;
    private readonly HttpClient _http =new HttpClient();
    public async Task<string> InvokeService()
    {
        var res= "";
        var consulClient = new ConsulClient(opt=>{
            opt.Address = new Uri("http://localhost:8500");
        });
        var queryResult = await consulClient.Catalog.Service("api/WeatherForecast");
        var serviceUris = new List<string>();
        foreach(var item in queryResult.Response)
        {
             serviceUris.Add(item.ServiceAddress + ":" + item.ServicePort);
        }
        // HttpClient httpClient = _httpFactory.CreateClient();
        HttpResponseMessage response = await _http.GetAsync(serviceUris[0] + "/api/Values");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            res = await response.Content.ReadAsStringAsync();
        }
        return res;
    }

}