using Microsoft.AspNetCore.Mvc;
using PuroVoteSystem.Mvc.Models;
using System.Diagnostics;

namespace PuroVoteSystem.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles ="管理员")]
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "普通用户")]
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Enum()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}