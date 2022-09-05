using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Identity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> m_userManager;
        private readonly SignInManager<IdentityUser> m_signManager;
        private readonly RoleManager<IdentityRole> m_roleManager;

        public HomeController(UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signManager,RoleManager<IdentityRole> roleManager)
        {
            m_userManager = userManager;
            m_signManager = signManager;
            m_roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string userName,string password)
        {
            var user = await m_userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var res = await m_signManager.PasswordSignInAsync(user, password, false, false);
            
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Email, user.Email));
                await m_signManager.SignInWithClaimsAsync(user, true, claims);
                
         
                if (res.Succeeded)
                {
                    return RedirectToAction("Privacy");
                }
            }
          
           
            return View("发生了错误");
            
          
        }
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(string userName,string password)
        {
            var user = new IdentityUser()
            {
                UserName = userName,   
                Email ="123@qq.com"
            };
            var role = new IdentityRole()
            {
                Name = "Admin"
            };
            var res = await m_userManager.CreateAsync(user,password);//新增一个identityUser
            var r = await m_roleManager.CreateAsync(role);//新增一个identityRole
            var r2 = await m_userManager.AddToRoleAsync(user,role.Name);
            Claim myClaim = new Claim(ClaimTypes.Email, user.Email);//子声明
            Claim Country = new Claim(ClaimTypes.Country, "China");
           
            if (res.Succeeded)
            {
                var user2 = await m_userManager.FindByNameAsync(userName);
                var res2 = await m_signManager.PasswordSignInAsync(user2, password, false, false);
                var r3 = await m_userManager.AddClaimAsync(user, Country);
                IList<Claim> claims = await m_userManager.GetClaimsAsync(user2);//声明集合
                await m_signManager.SignInWithClaimsAsync(user2, true,claims);
                if (res2.Succeeded)
                    return RedirectToAction("Privacy");               
            }      
            return View(res.Errors);

        }
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}