using System.Net;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcClient.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json.Linq;
using IdentityModel.Client;

namespace MvcClient.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    [HttpGet]
    public IActionResult Logout()
    {
        return SignOut("Cookies", "oidc");
    }
    [HttpGet]
    public async  Task<IActionResult> GetApi1()
    {
        var accessToken = await HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

        var apiClient = new HttpClient();
        apiClient.SetBearerToken(accessToken);
        var response = await apiClient.GetAsync("https://localhost:7069/WeatherForecast");
        System.Console.WriteLine(accessToken);
        if(!response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.StatusCode);
        }
        else
        {
            var json =  await response.Content.ReadAsStringAsync();
            Console.WriteLine(json);//Newtonsoft nuget  using Newtonsoft.Json.Linq
        }
        return Content("");
       
    }
}
