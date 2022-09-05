using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,"myName"),
                new Claim(ClaimTypes.Email,"Name@qq.com"),
                new Claim("MyClaim","yes")
            };
            var myIdentity = new ClaimsIdentity(claims, "My Idnetity");
            var userPrincipal = new ClaimsPrincipal(new[] { myIdentity });
            HttpContext.SignInAsync(userPrincipal);
            return View();
        }
        [Authorize]
        public IActionResult Privacy()
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