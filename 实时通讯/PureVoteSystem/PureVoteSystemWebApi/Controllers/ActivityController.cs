
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PureVoteSystemWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ActivityController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetActivities()
        {
            var activities = _context.SystemActivity.AsQueryable().ToList();
            //_mapper.Map<List<SystemActivity>, List<ActivityIndexViewModel>>(activities);
            return new JsonResult(activities);
        }
        [HttpPost]
        public IActionResult UpdateActivites([FromBody]SystemActivity activity)
        {
            _context.SystemActivity.Update(activity);
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return new JsonResult(true);
            }
            return new JsonResult(false);
        }
    }
}
