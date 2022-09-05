using Microsoft.AspNetCore.Mvc;

namespace VoteSystem.Web.Entry.Controllers
{
    public class VoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
