
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using PuroVoteSystem.Mvc.Models.DoorViewModel;
using PuroVoteSystem.Mvc.Utils.FileManager;
using PuroVoteSystem.Mvc.Models.ForeDto.ChangePassword;

namespace PuroVoteSystem.Mvc.Controllers
{
    [AllowAnonymous]
    public class DoorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;

        public DoorController(AppDbContext context,IHttpContextAccessor contextAccessor, IMapper mapper,IDistributedCache cache)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
            _cache = cache;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public IActionResult Login(string returnUrl=null)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string returnUrl = null)
        { 
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            //登录逻辑
            var res = _context.SystemUser.Include(c=>c.Role).FirstOrDefault(c => c.Account == loginViewModel.Account && c.Password == passwordHash(loginViewModel.Password));

            if (res != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,res.UserName),
                    new Claim(ClaimTypes.Email,res.Email),
                    new Claim("Id",res.Id.ToString()),
                    new Claim(ClaimTypes.DateOfBirth,res.Birthday.ToString()),
                    new Claim("RoleName",res.Role.RoleName),
                    new Claim("RoleId",res.RoleId.ToString()),
                    new Claim(ClaimTypes.Role,res.Role.RoleName),
                    new Claim("Avator",res.Photo)
                };
                var myIdentity = new ClaimsIdentity(claims, "My Idnetity");
                var userPrincipal = new ClaimsPrincipal(new[] { myIdentity });              
                await _contextAccessor.HttpContext.SignInAsync(userPrincipal, new AuthenticationProperties { 
                IsPersistent=loginViewModel.RemeberMe });
            }
            else
            {
                ModelState.AddModelError("","登录失败,验证失败");
                return View(loginViewModel);
            }
            if (returnUrl == null)
            {
                return RedirectToAction("Index", "Activity");
            }
 
            return Redirect(returnUrl);
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [HttpGet]
       
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel,[FromServices] IWebHostEnvironment evn)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = _mapper.Map<SystemUser>(registerViewModel);
          
            user.Photo = MyFileClass.GetFileName(registerViewModel.Avator, evn);

            user.Account = registerViewModel.Email;
            _context.SystemUser.Add(user);
            var res = _context.SaveChanges();

            if (res == 1)
            {
                await MyFileClass.FileUpLoadAsync(registerViewModel.Avator,user.Photo,evn);
            }

            return RedirectToAction("Login");
        }

        new public async Task<IActionResult> SignOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _contextAccessor.HttpContext.SignOutAsync();
            }

            //return View("../Door/Login");
            return LocalRedirect("~/door/login");
        }


        private string passwordHash(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                var output = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                var text = BitConverter.ToString(output).Replace("-", " ");
                return text;
            }
        }
        //获取文件名
        public string GetFileName(IFormFile file, IWebHostEnvironment evn)
        {
            var uniqueFileName = "default.jpg";
            if (file != null)
            {
                uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            }
            return uniqueFileName;

        }
        //文件上传
        public async Task FileUpLoadAsync(IFormFile file,string fileName,IWebHostEnvironment evn)
        {
            var uploadFolder = Path.Combine(evn.WebRootPath, "Image/DefaultAvator");//获取wwwroot下的图片资源根路径
         
            var filePath = Path.Combine(uploadFolder, fileName);
            
            filePath = Path.Combine(uploadFolder, fileName);
            await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
           
        }
        #region 修改密码 忘记密码
        /// <summary>
        /// 修改密码主页 填写邮箱信息
        /// </summary>
        /// <returns></returns>
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordIndex changeModel)
        {
            //判断邮箱与账户是否对应
            var res =  _context.SystemUser.FirstOrDefault(c => c.Account == changeModel.Account && c.Email == changeModel.Email);
            if (res == null)
            {
                ModelState.AddModelError("","对不起请核实您的账号或邮箱");
                return View(changeModel);
            }
            TempData["Email"] = changeModel.Email;
            return RedirectToAction("GenerateCode", new { email = changeModel.Email});
        }
        /// <summary>
        /// 用户输入自己的新密码
        /// </summary>
        /// <returns></returns>
        public IActionResult NewPassword(string email)
        {
            ViewBag.Email = email;
            return View();
        }
       
        /// <summary>
        /// 更新到数据库
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NewPassword(NewPasswordModel model)
        {
            var redisCode = _cache.GetString(model.Email);
            ViewBag.Email = model.Email;
            if (model.Password2 != model.Password1)
            {
                ModelState.AddModelError("", "对不起您两次密码不一致");
                return View(model);
            }
            if (model.Code != redisCode)
            {
                ModelState.AddModelError("","对不起您的Code代码不正确");
                return View(model);
            }
            if (string.IsNullOrEmpty(redisCode))
            {
                ModelState.AddModelError("","您的Code代码过期了");
                return View(model);
            }
            TempData["password"] = model.Password1;
            return RedirectToAction("ChangeUserPassword", new { email=model.Email});
        }

        /// <summary>
        /// 验证邮箱是否存在
        /// </summary>
        /// <param name="userEmail">用户输入的邮箱</param>
        /// <param name="account">用户的账户</param>
        /// <returns></returns>
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyEmail(string Email)
        {

            var email = _context.SystemUser.FirstOrDefault(c => c.Email == Email);
            if (email != null)
            {
                return Json(true);
            }
            else
            {
                return Json($"邮箱： {Email} 不存在。");
            }
        }
        /// <summary>
        /// 生成验证码 将验证码存入reids 存2分钟 将Code发送给用户邮箱
        /// </summary>
        /// <returns></returns>
       
        public async Task<IActionResult> GenerateCode(string email,[FromServices] IFluentEmail fluentEmail)
        {
            ViewBag.Email = email;
            string code = "";
          
            for (int i = 0; i < 5; i++)
            {
                code += Random.Shared.Next(1, 10);              
            }
            code.Trim();
           
            //将生成的验证码存入reids
            _cache.SetString(email,code,new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow=TimeSpan.FromMinutes(3)});

            var emailSender = fluentEmail.To(email).Subject(" 这是您的Code ").Body($"<h3>请不要随意透露给任何人</h3><h1 style='color:#00FFFF'>{code}</h1>", true);

            var res = await emailSender.SendAsync();
            if (!res.Successful)
            {
                return View("../Error/EmailSenderError");
            }
            return View();
        }
        /// <summary>
        /// 验证code
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<IActionResult> VerifyCode(string email,string code)
        {
            string redisCode = await _cache.GetStringAsync(email);
            if (string.IsNullOrEmpty(redisCode))
            {
                return Content("对不起,您的Code已过期");
            }
        
            return View();
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IActionResult ChangeUserPassword(string email)
        {
            var userPassword = TempData["password"].ToString();
            if (string.IsNullOrEmpty(userPassword))
            {
                return Content("session中的密码为空");
            }
            var user = _context.SystemUser.FirstOrDefault(c => c.Email == email);
            user.Password = userPassword;
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return View();//提示用户密码修改成功
            }

            return View();//提示用户密码修改失败
        }
        #endregion
    }
}
