using Microsoft.AspNetCore.Mvc;

namespace Furion.Mvc.Entry.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var httpContext = HttpContext;

            //var ipv4 = httpContext.GetLocalIpAddressToIPv4();

            //var ipv6 = httpContext.GetRemoteIpAddressToIPv6();

            return View();
        }
    }
}
