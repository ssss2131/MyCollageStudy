using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using IIIServerApi.Models;

namespace IIIServerApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{

    [HttpGet()]
    public ActionResult<IEnumerable<string>> Get()
    {
        return new string[] {"value1 from IIIserver Api", "value2 from IIIserver Api" };
    }

}
