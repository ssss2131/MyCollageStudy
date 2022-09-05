using fluentEmail;
using IdentityFirst.Data.MyModel;
using IdentityFirst.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IdentityFirst.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _userSigin;

        public HomeController(ILogger<HomeController> logger, UserManager<MyUser> userManager, SignInManager<MyUser> userSigin)
        {
            _logger = logger;
            _userManager = userManager;
            _userSigin = userSigin;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string userName, string passwordHash, string ReturnUrl = "")
        {
            var entity = await _userManager.FindByNameAsync(userName);

            ReturnUrl = TempData["ReturnUrl"].ToString();

            var res = await _userSigin.PasswordSignInAsync(entity, passwordHash, true, false);
            if (res.Succeeded)
            {
                return LocalRedirect($"/home/VerifyEmail?userName={entity.UserName}");
                //return LocalRedirect($"/home/VerifyEmail?userName={entity.UserName}");
            }
            return LocalRedirect($"/home/VerifyEmail?userName={entity.UserName}");

        }
        public IActionResult VerifyEmail(string userName)
        {
            ViewData["userName"] = userName;
            return View();
        }

        //系统发邮件
        [HttpPost]
        public async Task<IActionResult> VerifyEmail([FromServices] MyFluentEmail emailService,[FromForm] string userName)
        {
            var entity = await _userManager.FindByNameAsync(userName);
         
            if (entity != null)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(entity);

                emailService.ToEmail = entity.Email;
                emailService.FromEmail = "1824782123@qq.com";
                var title = "这是一次验证邮箱";
                var link = Url.Action(nameof(Verify), "Home", new { userId = entity.Id,code = code},Request.Scheme,Request.Host.ToString());
                var context = $@"<a href='{link}'>请确认您的邮箱</a>";

                emailService.SendMessage(title, context);
            }
            return Content("ok");
        }

        //验证邮箱
        public async Task<ActionResult> Verify(string code,string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var res = await _userManager.ConfirmEmailAsync(user, code);            
                if (res.Succeeded)
                {
                    return RedirectToAction("VerifySuccessed", new { userName = user.UserName, code = code });
                }
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> VerifySuccessed(string userName,string code)
        { 
            var entity = await _userManager.FindByNameAsync(userName);
            await _userSigin.SignInAsync(entity, true,code);
            return Content("ok");
        }

        [HttpGet]
        new public async Task<IActionResult> SignOut()
        {
            await _userSigin.SignOutAsync();
            return LocalRedirect("~/HOME/LOGIN");
        }
        [HttpGet]
        public IActionResult Register(string returnUrl="")
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm]string userName,string passwordHash,string MySpecificUser,string Email)
        {
            var user = new MyUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = userName,
                MySpecificUser = MySpecificUser,
                Email = Email
            };

            var res = await _userManager.CreateAsync(user, passwordHash);
            if (res.Succeeded)
            {
                return RedirectToAction("Index");
            }
            foreach (var error in res.Errors)
            {
                Console.WriteLine(error);
            }
            return View();
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
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