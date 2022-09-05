using Cache.Data;
using Cache.Data.Models;
using Cache.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cache.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices] AppDbContext context)
        {
            //context.Database.EnsureCreated();
    
            if (context.MyNumbers != null)
            {
                context.MyNumbers.Add(new Numbers("1") { Id = 1 });
                context.MyNumbers.Add(new Numbers("2") { Id = 2 });
                context.MyNumbers.Add(new Numbers("3") { Id = 3 });
                context.MyNumbers.Add(new Numbers("4") { Id = 4 });
                context.MyNumbers.Add(new Numbers("5") { Id = 5 });
                context.MyNumbers.Add(new Numbers("6") { Id = 6 });
                context.MyNumbers.Add(new Numbers("7") { Id = 7 });
                context.SaveChanges();
            }
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
    }
}