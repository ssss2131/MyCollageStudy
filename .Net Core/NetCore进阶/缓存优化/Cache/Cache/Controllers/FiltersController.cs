using Cache.Data;
using Cache.Data.Options;
using Microsoft.AspNetCore.Mvc;

namespace Cache.Controllers
{
    public class FiltersController : Controller
    {
        /// <summary>
        /// 异常过滤器
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public IActionResult Index()
        {
            throw new Exception("发生了一些错误，并且被自定义过滤器拦截");
        }
        /// <summary>
        /// 事务过滤器
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IActionResult> TransactionFilters([FromServices] AppDbContext context)
        {
            context.MyNumbers.Add(new Data.Models.Numbers(url:"new"));
            await context.SaveChangesAsync();
            throw new Exception("假如添加失败");
            context.MyNumbers.Add(new Data.Models.Numbers(url: "new2"));
            await context.SaveChangesAsync();
            return Content(context.MyNumbers.Count().ToString());
        }
        public IActionResult Count([FromServices] AppDbContext context)
        {
            return Content(context.MyNumbers.Count().ToString());
        }
        /// <summary>
        /// RateFilter
        /// </summary>
        /// <returns></returns>
        public IActionResult RateLimit()
        {

            return View();
        }
    }
}
