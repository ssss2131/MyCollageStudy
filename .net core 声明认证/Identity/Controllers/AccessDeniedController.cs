using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    public class AccessDeniedController : Controller
    {
        
        public IActionResult Denied()
        {
            return View();
        }
    }
}
