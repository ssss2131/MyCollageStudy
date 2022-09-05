using ApiResource.Model;
using HelloRedis.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presntation.Domain;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Tools.Dto;
using Tools.RabbitMQ;


namespace ApiResource.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService m_StockService;
        private readonly AbsRabbitMQ m_rabbitHelper;
        public StockController(IStockService stockService, AbsRabbitMQ rabbitHelper)
        {
            m_StockService = stockService;
            m_rabbitHelper = rabbitHelper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {        
            var stockInDb = await m_StockService.GetStokWithBookInfo();
            List<StockViewModel> modelList = new List<StockViewModel>();
            foreach (var item in stockInDb)
            {
                modelList.Add(new StockViewModel { bookName = item.Book.BookName, count = item.Count, authorId = item.Book.AuthorId, isbn = item.Book.ISBN,id = item.BookId });
            }
            return new JsonResult(modelList);//这个东西 ！！！会把变量名改成驼峰法
        }

        //[HttpPost]
        /////采购图书
        //public async Task<IActionResult> PurchaseBookInStock(CreateBookModel model)
        //{
        //    //通过书名采购新的图书
        //    m_rabbitHelper.Message = JsonSerializer.Serialize(model);
        //    m_rabbitHelper.SendMessage();

        //    m_rabbitHelper.GetMessage();


        //    return new JsonResult(m_rabbitHelper.ReciveMessage);
        //}
        [HttpPost]
        public async Task<IActionResult> SendoutBookInStock(List<Book> books)
        {
            return new JsonResult("");
        }

        [HttpPost]
        public async Task<bool> PurchaseBookInStock(string stockId, string number)
        {
            Console.WriteLine(stockId + number);
            var stock = await m_StockService.QueryOne(c => c.Id == int.Parse(stockId));
            //var stock = await m_StockService.GetByIdAsync(int.Parse(stockId));
            stock.Count += int.Parse(number);
            return await m_StockService.PutEnityAsync(stock);
        }
        [HttpPost]
        public async Task<string> Test(string stockId)
        {
            Console.WriteLine("请求成功"+DateTime.Now);
            return "Ok";
        }


    }
}
