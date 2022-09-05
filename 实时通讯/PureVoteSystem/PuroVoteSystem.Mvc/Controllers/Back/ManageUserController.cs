using Microsoft.AspNetCore.Mvc;
using PuroVoteSystem.Mvc.Models.BackDto.SearchModel;

namespace PuroVoteSystem.Mvc.Controllers.Back
{
    /// <summary>
    /// 用户信息查看
    /// </summary>
    [Authorize(Roles = "管理员")]
    public class ManageUserController : Controller
    {
        private readonly AppDbContext _context;

        public ManageUserController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult UserDetail(int userId)
        {
            var user = _context.SystemUser.FirstOrDefault(c => c.Id == userId);
            if (user == null)
            {
                return Content("<script>alert('用户Id不存在');</script>", "text/html");
            }

            return View(user);
        }
        /// <summary>
        /// 通过姓名查询用户信息
        /// </summary>
        /// <returns></returns>
        public IActionResult SearchIndex()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SearchUserByName([FromForm]SearchViewModel model)
        {
            var users = _context.SystemUser.Where(c => c.UserName.Contains(model.UserName)).ToList();

            if (users.Count() <= 0)
            {
                return View("../Error/NotFoundUser");
            }

            return View(users);
        }
    }
}
