using Microsoft.AspNetCore.Mvc;

namespace Identity.Component
{
    public class HelloCom:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
