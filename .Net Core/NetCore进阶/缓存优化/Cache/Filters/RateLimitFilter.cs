using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filters
{
    public class RateLimitFilter : IAsyncActionFilter
    {
        private readonly IMemoryCache _cache;

        public RateLimitFilter(IMemoryCache cache)
        {
            _cache = cache;
        }
        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
            string cacheKey = $"Visited key {ipAddress}";
            long? lastTick = _cache.Get<long?>(cacheKey);
            if (lastTick == null || Environment.TickCount64 - lastTick > 1000)
            {
                _cache.Set<long?>(cacheKey, Environment.TickCount64, TimeSpan.FromSeconds(10));
                return next();
            }
            else
            {
                context.Result = new ContentResult { StatusCode = 429 };
                return Task.CompletedTask;                     
            }
  
        }
    }
}
