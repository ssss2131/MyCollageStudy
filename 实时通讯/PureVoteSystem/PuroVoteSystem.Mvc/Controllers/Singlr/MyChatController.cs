using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers.Singlr
{
    public class MyChatController : Controller
    {
        private readonly AppDbContext _context;

        public MyChatController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ChatIndex()
        {
            return View();
        }
        public IActionResult EchartIndex()
        {
            return View();
        }
        public IActionResult ChatGroup(int actId)
        {
            //var title = _context.SystemActivity.FirstOrDefault(c => c.Id == actId).Title;
            return View();
        }
    }
}
