using Microsoft.AspNetCore.Mvc;

namespace NetCoreFoundation.Areas.Products.Controllers
{
    [Area("Products")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
