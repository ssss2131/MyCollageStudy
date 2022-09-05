using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Component
{
    public class LoginCom:ViewComponent
    {
        private readonly UserManager<IdentityUser> m_userManager;
        private readonly SignInManager<IdentityUser> m_signInManager;

        public LoginCom(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            m_userManager = userManager;
            m_signInManager = signInManager;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
