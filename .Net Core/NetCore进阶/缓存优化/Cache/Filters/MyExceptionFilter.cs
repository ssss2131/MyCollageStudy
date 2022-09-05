using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Filters
{
    public class MyExceptionFilter : IAsyncExceptionFilter
    {
        private readonly ILogger<MyExceptionFilter> _logger;
        private readonly IHostEnvironment _ienv;

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger,IHostEnvironment ienv)
        {
            _logger = logger;
            _ienv = ienv;
        }
#pragma warning disable CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        public async Task OnExceptionAsync(ExceptionContext context)
#pragma warning restore CS1998 // 异步方法缺少 "await" 运算符，将以同步方式运行
        {
            Exception exception = context.Exception;

            _logger.LogError(exception,"Exception Happened");

            string message="";

            if (_ienv.IsDevelopment())
            {
                message = exception.Message;
            }
            else
            {
                message = "Nothing Happen In This Enviroment";
            }
            ObjectResult result = new ObjectResult(new { code = 500, message = message });
            result.StatusCode = 500;
            result.Value = exception;
            context.Result = result;
            context.ExceptionHandled = true;        
        }
    }
}