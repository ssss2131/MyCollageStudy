using Microsoft.AspNetCore.Mvc;

namespace VoteSystem.Wen.UI.Controllers
{
    public class CommonController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
