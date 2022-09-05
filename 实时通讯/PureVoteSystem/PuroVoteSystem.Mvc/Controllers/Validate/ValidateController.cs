using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers.Validate
{
    public class ValidateController : Controller
    {
        private readonly AppDbContext _context;

        public ValidateController(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 登录时邮箱校验
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> ValidateForEmail(string email)
        {

            var user = await _context.SystemUser.FirstOrDefaultAsync(c => c.Email == email);

            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"邮箱： {email} 已经被注册使用了。");
            }
         
        }
    }
}
