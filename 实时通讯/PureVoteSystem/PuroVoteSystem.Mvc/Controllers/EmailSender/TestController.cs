using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers.EmailSender
{
    public class TestController : Controller
    {
        public async Task<IActionResult> SendEmail([FromServices] IFluentEmail singleEmail)
        {
            var email1 = singleEmail.To("2446216755@qq.com").Subject("Test email 1").Body("This is the first email");
            await email1.SendAsync();
            return View();
        }
    }
}
