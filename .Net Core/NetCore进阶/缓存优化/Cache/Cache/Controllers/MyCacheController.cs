using Cache.Data;
using Cache.Data.Models;
using CacheTools.MemoCache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Cache.Controllers
{
    public class MyCacheController : Controller
    {
        private readonly IMemoryCache _memoryCache;
        private readonly AppDbContext _dbcontext;
        private readonly IDistributedCache _cache;

        public MyCacheController(IMemoryCache memoryCache, AppDbContext dbcontext,
                                IDistributedCache cache)
        {
            _memoryCache = memoryCache;
            _dbcontext = dbcontext;
            _cache = cache;
        }
        /// <summary>
        /// 客户端缓存
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 60)]
        [HttpGet]
        public IActionResult BrowserCache()
        {   
            var rand = DateTime.Now;

            return Content("<h1>" + rand.ToString() + "</h1>"+"<a href='/MyCache/MemoCache'>MemoCache</a>", "text/html");
        }

        /// <summary>
        /// 使用内存中的缓存
        /// </summary>
        /// <param name="memoryCache"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MemoCache([FromServices] IMemoryCache memoryCache)
        {
            string content = "Not CacheContent";         
            content = memoryCache.GetOrCreate<string>("hello", (e) =>
            {
                e.AbsoluteExpirationRelativeToNow=TimeSpan.FromSeconds(1);
                //e.SlidingExpiration = TimeSpan.FromSeconds(3);
                var rand = Random.Shared.Next(1, 3);
                if (rand >= 2)
                    return "CacheContent";
                else
                    return content;
            });
            Console.WriteLine(memoryCache.Get("hello"));

            return Content("<h1>"+content+"</h1>","text/html");           
        }
        /// <summary>
        /// 防止缓存穿透  =>原理 就是没找着 就在缓存中存一个null字符串 防止雪崩 为每个值 设置一个随机数 随机数生成过期时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult GetNumbers([FromRoute] int id, [FromServices] AppDbContext context)
        {      
            var res = _memoryCache.GetOrCreate<string>(id.ToString(), (e) => {
                var expireTime = Random.Shared.Next(30, 60);
                e.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(expireTime);
                e.SlidingExpiration = TimeSpan.FromMinutes(expireTime);
                var entity = context.Set<Numbers>().FirstOrDefault(c => c.Id == id);
                var text = "";
                if (entity != null)
                {
                    text = JsonSerializer.Serialize<Numbers>(entity);
                }
                else
                {
                    text = "null";
                }
                return text;
            }); 

            return Content($"<h1>{res}</h1>","text/html");
        }

        public IActionResult CacheToolGet([FromRoute] int id, [FromServices] ICacheHelper CacheHelper)
        {
            
            var res = CacheHelper.GetOrCreate(id.ToString(), (e) => {
                var entity = _dbcontext.Set<Numbers>().FirstOrDefault(c => c.Id == id);
                var text = JsonSerializer.Serialize<Numbers>(entity);
                return text;
            },60);
            return Content($"<h1>{res}</h>","text/html");    
        }

        public IActionResult RedisCache()
        {
            _cache.SetString("1", "hello");

            return Content($"<h1>{_cache.GetString("1")}</h1>", "text/html");

        }
    }
}
