using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers
{
    [AllowAnonymous]
    public class DeinedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
