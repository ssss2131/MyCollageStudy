

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyFilter.Models;

namespace MyFilter.Filters
{
    public class MyExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //if (context.ExceptionHandled == false)
            //{
            //    context.Result = new ContentResult
            //    {
            //        Content = context.Exception.Message,//这里是把异常抛出。也可以不抛出。
            //        StatusCode = StatusCodes.Status200OK,
            //        ContentType = "text/html;charset=utf-8"
            //    };
            //}
            //context.ExceptionHandled = true;
            if (context.ExceptionHandled == false)
            {

                ErrorViewModel model = new ErrorViewModel
                {
                    RequestId = context.HttpContext.Request.Method.ToString(),

                };           
                var error = context.Exception.Message;
                context.Result = new ViewResult() {ViewName="~/Views/Shared/MyError.cshtml" };
            }
            context.ExceptionHandled = true;


        }
    }
}
