using Microsoft.AspNetCore.Mvc;

namespace PuroVoteSystem.Mvc.Controllers.Back
{
    /// <summary>
    /// 选手信息查看
    /// </summary>
    [Authorize(Roles ="管理员")]
    public class ManageCandidateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
