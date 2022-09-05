using Microsoft.AspNetCore.Mvc;
using PuroVoteSystem.Mvc.Utils.FileManager;
using System.Security.Claims;

namespace PuroVoteSystem.Mvc.Controllers.Back
{
    /// <summary>
    /// 活动管理
    /// </summary>
    [Authorize(Roles ="管理员")]
    public class ManageActController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;
        private readonly IWebHostEnvironment _ievn;

        public ManageActController(AppDbContext context,IMapper mapper,IHttpContextAccessor accessor,IWebHostEnvironment ievn)
        {
            _context = context;
            _mapper = mapper;
            _accessor = accessor;
            _ievn = ievn;
        }
        /// <summary>
        /// 活动主页面
        /// </summary>
        /// <returns></returns>
        
        public IActionResult ActIndex(int page=1,int pagesize=15)
        {
            var entities = _context.SystemActivity.AsQueryable().Skip(pagesize * (page - 1)).Take(pagesize).ToList();

            return View(_mapper.Map<List<SystemActivity>, List<ActivityIndexViewModel>>(entities));
        }
        public IActionResult DeleteAct(int id)
        {
            var entity =  _context.SystemActivity.Where(c => c.Id == id).FirstOrDefault();

            _context.SystemActivity.Remove(entity);
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return RedirectToAction("ActIndex");
            }
            else
            {
                return Content("<script>alert('删除失败');history.go(-1);</script>", "text/javascript");
            }

        }

        public IActionResult AddAct()
        {
             
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAct(ActivityAddDto activity,IFormFile myFile)
        {
            if (!ModelState.IsValid)
            {          
                return View(activity);
            }
            if (activity.WhenStart < DateTime.Now || activity.WhenStart >=activity.WhenEnd)
            {
                ModelState.AddModelError("", "活动开始结束时间不正确,请修改");
                return View(activity);
            }
            if (myFile != null)
            {
                var fileName = MyFileClass.GetFileName(myFile, _ievn);
                await MyFileClass.FileUpLoadAsync(myFile, fileName, _ievn);
            }

            var userEmail = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value;
            activity.WhoSend = userEmail;
            var target = _mapper.Map<SystemActivity>(activity);
            _context.SystemActivity.Add(target);
            _context.SaveChanges();
            return RedirectToAction("ActIndex");
        }

        /// <summary>
        /// 修改活动信息 页面展示
        /// </summary>
        /// <param name="id">活动Id</param>
        /// <returns></returns>
        public IActionResult ActEdit(int id)
        {
            var entitiy =  _context.SystemActivity.FirstOrDefault(c => c.Id == id);
            return View(entitiy);
        }
        /// <summary>
        /// 修改活动的逻辑
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ActEdit(SystemActivity activity,IFormFile myFile)
        {
            if (!ModelState.IsValid||activity.WhenStart>activity.WhenEnd)
            {
                ModelState.AddModelError("", "日期错误:开始时间必须小于结束时间");
                return View();
            }         
            if(myFile != null)
            {
                var fileName = activity.Photo;
                //if (!string.IsNullOrEmpty(activity.Photo))
                //{
                //    MyFileClass.FileRemove(activity.Photo, _ievn);//删除系统中的原有文件
                //}
                fileName = MyFileClass.GetFileName(myFile, _ievn);//获取修改的文件名
                activity.Photo = fileName;
                _context.SystemActivity.Update(activity);
                var res = _context.SaveChanges();
                if (res > 0)
                {
                    await MyFileClass.FileUpLoadAsync(myFile, fileName, _ievn);//新文件上传到服务器
                    return RedirectToAction("ActIndex");
                }
                else
                {
                    ModelState.AddModelError("", "发生异常");
                    return View(activity);
                }               
            }
            //if (!string.IsNullOrEmpty(activity.Photo))
            //{
            //    MyFileClass.FileRemove(activity.Photo, _ievn);//删除系统中的原有文件
            //}
            activity.Photo = "";
            _context.SystemActivity.Update(activity);
            _context.SaveChanges();

            return RedirectToAction("ActIndex");      
        }
        
        public IActionResult AddUserInActivity(int actId)
        {
            var managers = _context.SystemCandidateManager.Where(c => c.SystemActivityId == actId).Include(c => c.SystemUser).Where(c=>c.SystemUser.RoleId==2).AsQueryable();
            var activity = _context.SystemActivity.FirstOrDefault(c => c.Id == actId);
            var sysUsers = _context.SystemUser.Where(c=>c.RoleId==2).AsQueryable();//获取所有选手信息
            ViewBag.myTitle = activity.Title;
            ViewBag.actId = int.Parse(actId.ToString());
            var userIds = new List<int>();
            foreach (var item in managers)
            {
                userIds.Add(item.SystemUser.Id);
            }
            var dtos = new List<CandidateManagerDto>();
            foreach (var item in sysUsers)
            {
                
                if (userIds.Contains(item.Id))
                {
                    continue;
                }
                dtos.Add(new CandidateManagerDto { IsShow = true, UserId = item.Id, UserName = item.UserName });
            }
          
            return View(dtos);
        }
         
        public IActionResult AddUserInAct(int userId, int actId)
        {
            _context.SystemCandidateManager.Add(new SystemCandidateManager { SystemActivityId = actId, SystemUserId = userId });
            _context.SaveChanges();
            return RedirectToAction("AddUserInActivity", new { actId = actId});
        }
        public IActionResult RemoveUserInActivity(int actId)
        {
            var actitityInfo = _context.SystemCandidateManager.Include(c => c.SystemUser).Where(c => c.SystemActivityId == actId);
            var users = new List<SystemUser>();
            foreach (var item in actitityInfo)
            {
                users.Add(item.SystemUser);
            }
            ViewBag.actId = actId;
            return View(users);
        }

        public IActionResult RemoveUserInAct(int userId, int actId)
        {
            var entity = _context.SystemCandidateManager.Where(c => c.SystemUserId == userId && c.SystemActivityId == actId).FirstOrDefault();
            _context.SystemCandidateManager.Remove(entity);
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return Content("<script>alert('succeed');history.go(-1);</script>", "text/html");
            }
            else 
            {
                return Content("<script>alert('failed');history.go(-1);</script>", "text/html");
            }        
        }
    }
}
