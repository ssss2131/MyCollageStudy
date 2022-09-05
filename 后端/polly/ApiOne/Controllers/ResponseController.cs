using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using apione.Models;

namespace apione.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
    
        [HttpGet]
        public IActionResult GetResponse(int id)
        {
            Random random = new Random();
            var rand = random.Next(1,101);
            if(id>=rand)
            {
                System.Console.WriteLine("-->成功 --产生信息200");
                return Ok();
            }
            System.Console.WriteLine("-->失败 --产生信息500 ");
            return StatusCode(StatusCodes.Status500InternalServerError);
            
        }
    }
}