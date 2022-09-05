using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
 
using System.Security.Claims;
using System.Text.Json;

namespace VoteSystem.Web.Entry.Controllers
{
    [AllowAnonymous]
    public class CommonController : Controller
    {
        private readonly IUserService _userService;

        public CommonController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            var res = await _userService.LoginAscyn(loginModel);
           
            if (res!=null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,res.Name),
                    new Claim(ClaimTypes.Email,res.Email),
                    new Claim("roles",res.YourRole.ToString())
                };
                var myIdentity = new ClaimsIdentity(claims, "My Idnetity");
                var userPrincipal = new ClaimsPrincipal(new[] { myIdentity });
                await HttpContext.SignInAsync(userPrincipal);
            }
            return View();
        }
    }
}
