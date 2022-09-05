using Microsoft.AspNetCore.Mvc;
using MyFilter.Filters;
using MyFilter.Models;
using System.Diagnostics;

namespace MyFilter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [MyActionFilterAttribute]
        public IActionResult Index()
        {
            return View();
        }
        [MyExceptionFilterAttribute]
        public IActionResult Privacy()
        {
            throw new Exception("cuowu");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}