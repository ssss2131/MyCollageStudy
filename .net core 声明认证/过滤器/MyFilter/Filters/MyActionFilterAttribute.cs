using Microsoft.AspNetCore.Mvc.Filters;
using System;


namespace MyFilter.Filters
{
    //动作过滤器
    public class MyActionFilterAttribute : ActionFilterAttribute
    {
        //将要执行Action的时候拦截下来
        #region ?
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var rand = new Random();
            var res = rand.Next(1, 10);
            if (res < 5)
                await context.HttpContext.Response.WriteAsync("Hello World");
            else
                await next();
        }
        #endregion



    }
}
