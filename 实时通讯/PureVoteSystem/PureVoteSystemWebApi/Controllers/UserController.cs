using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PureVoteSystemWebApi.Dto;

namespace PureVoteSystemWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserController(AppDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetUsers()
        {
            var res = _context.SystemUser.ToList();
            return new JsonResult(res);
        }
        [HttpGet]
        public IActionResult GetTimeByStamp(string timeStamp)
        {
            //1657209600000
            
            if (string.IsNullOrEmpty(timeStamp))
            {
                return new JsonResult(false);
            }
            var unixTimeStamp = long.Parse(timeStamp);

            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当			  地时区

            DateTime dt = startTime.AddMilliseconds(unixTimeStamp);
            var time = dt.ToString("yyyy-MM-dd HH:mm:ss ");
            return new JsonResult(time);
        }
        [HttpPost]
        public IActionResult PutUsers([FromBody] SystemUserDto user)
        {
            if (!ModelState.IsValid)
            {
                new JsonResult(user);
            }
            var timeStamp = user.TimeStamp;
            if (string.IsNullOrEmpty(timeStamp))
            {
                return new JsonResult(false);
            }
            long unixTimeStamp = 0;
            if (!long.TryParse(timeStamp, out unixTimeStamp))
            {
                return new JsonResult(false);
            }
            
 
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当			  地时区
 
            DateTime dt = startTime.AddMilliseconds(unixTimeStamp);
            var time = dt.ToString("yyyy-MM-dd HH:mm:ss ");
             
            var u = _mapper.Map<SystemUser>(user);
            u.Birthday = Convert.ToDateTime(time);
 
            _context.SystemUser.Update(u);
            var res = _context.SaveChanges();
            if (res > 0)
            {
                return new JsonResult(true);
            }
            else
            {
                return new JsonResult(false);
            }    

        }
        
    }
}
