using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserInfoController(AppDbContext context,IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }
        /// <summary>
        /// 用户查看自己的信息 
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration =60)]
        public IActionResult Index()    
        {        
            var id = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(c=>c.Type=="Id").Value;
            var userInfo = _context.SystemUser.FirstOrDefault(c => c.Id == int.Parse(id));
            if (userInfo != null)
            {
                return View(userInfo);
            }
            ModelState.AddModelError("", "用户信息异常");
            return View(userInfo);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            var userInfo = _context.SystemUser.FirstOrDefault(c => c.Id == int.Parse(id));
            return View(userInfo);
        }
        [HttpPost]
        public IActionResult Edit(SystemUser user)
        {


            return View("./Index", user);
        }

    }
}
