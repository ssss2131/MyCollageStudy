using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers.ChatForVate
{
    public class ChatController : Controller
    {
        private readonly AppDbContext _context;

        public ChatController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult ChatInAct(int actId)
        {       
            ViewBag.ActId = actId;  
            return View();
        }
    }
}
