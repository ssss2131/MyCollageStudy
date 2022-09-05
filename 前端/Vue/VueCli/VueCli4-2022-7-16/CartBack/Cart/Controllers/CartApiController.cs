using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartApiController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("获取成功");
        }
    }
}
