using ApiResource.Model;
using HelloRedis.Domain;
using HelloRedis.Repository;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.ViewModel;
using Presntation.Domain;
using Presntation.Domain.Service;
using System.Text.Json;
using System.Text.Unicode;
using Tools;
using Tools.Service;
using Tools.Dto;
using System.Net.Http;
using System.Text;

namespace Presentation.Controllers
{
    public class StockController : Controller
    {
        private readonly IStockService m_stockService;
        //private readonly IBookService m_bookService;
        private readonly IAuthorService m_authorService;
        private readonly IHttpClientFactory m_httpClient;
    
        public StockController(IStockService stockService, IHttpClientFactory httpClientFactory, IAuthorService authorService)
        {
            m_stockService = stockService;
            //m_bookService = bookService;
            m_authorService = authorService;
            m_httpClient = httpClientFactory;
        } 
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //var response = await m_httpClient.CreateClient().GetAsync("https://localhost:7130/api/Stock/Index");
            //if (response != null)
            //{
            //    string result = await response.Content.ReadAsStringAsync();
            //    Console.WriteLine(result);
            //    List<StockViewModel> stocks = JsonSerializer.Deserialize<List<StockViewModel>>(result);

            //    return View(stocks.ToList());
            //}
            //var StockList = await m_stockService.GetStokWithBookInfo();
            ////var StockList = await m_stockService.QueryAsync();
            //return NoContent();
            return View();
           
        }
        [HttpPost]
        public async Task<IActionResult> PurchaseBookInStock(int stockId,int number)
        {
            var stock = await m_stockService.GetByIdAsync(stockId);
            stock.Count += number;
            await m_stockService.PutEnityAsync(stock);
            return RedirectToAction("Index");
        }
        [HttpGet]       
        public async Task<IActionResult> AxiosGet()
        {
            var StockList = await m_stockService.GetStokWithBookInfo();
            //var StockList = await m_stockService.QueryAsync();       
            return new JsonResult(StockList);
        }
        [HttpGet]
        public async Task<IActionResult> PurchaseNewBook()
        {
     
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PurchaseNewBook(CreateNewBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Author author = new Author();
          
            var authorInDb = await m_authorService.QueryAsync(c => c.AuthorName == model.AuthorName);//假设作者名唯一
            if (authorInDb.Count() >0)
            {
                author = authorInDb.First();
            }
            else
            {             
                author.AuthorName = model.AuthorName;
                author.BirthTime = model.BirthTime;
            }
            //只考虑用户输入的书籍是唯一的 其他情况交由remote判断
            Book book = new Book
            {
                BookName = model.BookName,
                ISBN = model.ISBN,
                Publisher = model.Publisher,
                Author = author
            };
          
            Stock stock = new Stock
            {
                Book = book,
                Count = model.Count,
               
            };
            var res = await m_stockService.CreateAsync(stock);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetApi()
        {
            //var httpclient = new HttpClient();
            //var list = await httpclient.GetAsync("https://localhost:7130/api/Stock/Index");

            
            var response =  await m_httpClient.CreateClient().GetAsync("https://localhost:7130/api/Stock/Index");
            if (response != null)
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                List<StockViewModel> stocks = JsonSerializer.Deserialize<List<StockViewModel>>(result);
            }
            
            //foreach (var item in stocks)
            //{
            //    Console.WriteLine(item.Book.ISBN);
            //}
            
            return NoContent();
        }

        public async Task<IActionResult> InStockApi(/*CreateBookModel mode*/)
        {
            CreateBookModel model = new CreateBookModel();
            model.Publisher = "test";
            model.ISBN="test";
            model.Count = 100;
            model.BookName = "test";
            model.AuthorId = 2;
            var test = JsonSerializer.Serialize<CreateBookModel>(model);
            var data = new StringContent(test, Encoding.UTF8, "application/json");
            var response = await m_httpClient.CreateClient().PostAsync("https://localhost:7130/api/Stock/PurchaseBookInStock", data);
           
            return NoContent();
        }
       
    }
}
