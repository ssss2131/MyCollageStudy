using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class ActionFilterA : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Action ...in filter1");
            ActionExecutedContext con = await next();
            Console.WriteLine("Action ...out filter1");           
        }
    }
    public class ActionFilterB : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Action ...in filter2");
            ActionExecutedContext con = await next();
            Console.WriteLine("Action ...out filter2");
        }
    }
}
