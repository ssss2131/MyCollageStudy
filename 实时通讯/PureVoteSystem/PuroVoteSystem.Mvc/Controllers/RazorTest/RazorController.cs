using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers.RazorTest
{
    public class RazorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
