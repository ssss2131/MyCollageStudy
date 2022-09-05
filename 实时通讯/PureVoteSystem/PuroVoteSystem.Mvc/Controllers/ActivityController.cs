using Microsoft.AspNetCore.Mvc;
using PuroVoteSystem.Mvc.Models.EchartsDto;
using System.Text.Json;

namespace PuroVoteSystem.Mvc.Controllers
{
    /// <summary>
    /// 活动相关的控制器
    /// </summary>
    public class ActivityController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ActivityController(AppDbContext context,IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// 活动首页
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [ResponseCache(Duration = 600)]
        public IActionResult Index(int page = 1, int pagesize = 15)
        {
            var entities = _context.SystemActivity.AsQueryable().Skip(pagesize*(page-1)).Take(pagesize).ToList();
        
            return View(_mapper.Map<List<SystemActivity>, List<ActivityIndexViewModel>>(entities));
        }
        /// <summary>
        /// 活动详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseCache(Duration =600)]
        public IActionResult Details(int id)
        {
            var entity = _context.SystemActivity.AsNoTracking().FirstOrDefault(c => c.Id == id);
      
            return View(entity);
        }

        #region redis
        //public IActionResult SendToRedis()
        //{
        //    var entities = _context.SystemActivity.AsQueryable();
        //    if (entities != null)
        //    {
        //        foreach (var item in entities)
        //        {
        //            var text = JsonSerializer.Serialize(item);

        //            _cache.SetString(item.Id.ToString(), text, new DistributedCacheEntryOptions
        //            {
        //                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(Counter(DateTime.Now, item.WhenEnd))

        //            });

        //        }
        //    }
        //    return RedirectToAction("Index");
        //}
        #endregion
        /// <summary>
        /// 投票 展示所有参赛选手信息
        /// </summary>
        /// <param name="id">活动Id</param>
        /// <returns></returns>
 
        public IActionResult Vote(int id)
        {         
            var activity = _context.SystemCandidateManager.Include(c=>c.SystemUser).Include(c=>c.SystemActivity).Where(c=>c.SystemActivityId==id&&c.SystemUser.RoleId==2);
            var candidates = new List<UserInfoViewModel>();
            foreach (var item in activity)
            {
                candidates.Add(
                    new UserInfoViewModel
                    {
                        UserId = item.SystemUserId,
                        UserName = item.SystemUser.UserName,
                        ActivityId = item.SystemActivityId,
                        ActivityName = item.SystemActivity.Title
                    });                
            }                 
            return View(candidates);
        }
        /// <summary>
        /// 为某一选手投票
        /// </summary>
        /// <param name="id">选手id</param>
        /// <param name="actId">活动id</param>
        /// <param name="_accessor"></param>
        /// <returns></returns>
        public IActionResult VoteForU(int id,int actId,[FromServices] IHttpContextAccessor _accessor)
        {
        
            var userId = _accessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "Id").Value;//获取用户Id
            if (isCanVote(int.Parse(userId), actId, _context))
            {
                var target = _context.SystemCandidateManager.FirstOrDefault(c => c.SystemUserId == id && c.SystemActivityId == actId);
                target.CountVote += 1;
                _context.SystemCandidateManager.Add(new SystemCandidateManager { SystemActivityId = actId, SystemUserId = int.Parse(userId) });
                _context.SaveChanges();             
                return View("../Success/VoteSuccess");
            }
            else
            {
                return View("../Error/VoteError");
            }          　  
        }

        public IActionResult EchartsIndex(int actId)
        {
            var info = _context.SystemCandidateManager.FirstOrDefault(c => c.Id == actId);
            ViewBag.id = actId;
            return View();
        }


        /// <summary>
        /// Echarts 活动的数据
        /// </summary>
        /// <param name="actId">活动Id</param>
        /// <returns>echarts所需要的数据</returns>
        public IActionResult EchartsVoteActivity(int actId)
        {
           
            var info =  _context.SystemCandidateManager.Where(c => c.SystemActivityId == actId).Include(c=>c.SystemActivity).Include(c=>c.SystemUser).Where(c=>c.SystemUser.RoleId==2).AsQueryable();
            var echartModels = new List<EchartsViewModel>();
            foreach (var item in info)
            {
                echartModels.Add(new EchartsViewModel { userName = item.SystemUser.UserName ,voteNumber=item.CountVote});
            }
            
            return new JsonResult(echartModels);                       
        }
        /// <summary>
        /// 判断用户是否可以投票
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="actId">活动Id</param>
        /// <returns></returns>

        private bool isCanVote(int userId, int actId, AppDbContext context)   
        {
            var entities = context.SystemCandidateManager.Where(c => c.SystemUserId == userId&&c.SystemActivityId==actId);
            var MaxVoteNumber = context.SystemActivity.FirstOrDefault(c => c.Id == actId).EachVoteNumber;          
            var number = entities.Count();         
            return number < MaxVoteNumber ? true : false;
        }

        private int Counter(DateTime from,DateTime to)
        {
            var res =  (int)(to - from).TotalSeconds;
            return res;
        }
    }
}
