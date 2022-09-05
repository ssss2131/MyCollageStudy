using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using ConsulWebApi.Models;

namespace ConsulWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class healthcheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Healthcheck()
        {
            return new JsonResult("Ok");
        }
       
     


    }
}