//using IdentityModel.Client;
//using Newtonsoft.Json.Linq;

//var client = new HttpClient();
//var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
//if (disco.IsError)
//{
//    Console.WriteLine(disco.Error);
//    return;
//}
//var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
//{
//    Address = disco.TokenEndpoint,

//    ClientId = "Console AppId",
//    ClientSecret = "511536EF-F270-4058-80CA-1C89C192F69A",
//    Scope = "api1"//email无效 因为ClientCredential不代表任何用户 但email等信息代表的使用户 请求不合理
//});

//if (tokenResponse.IsError)
//{
//    Console.WriteLine(tokenResponse.Error);
//    return;
//}

//Console.WriteLine(tokenResponse.Json);


//client.SetBearerToken(tokenResponse.AccessToken);

//var response = await client.GetAsync("https://localhost:7130/Books/GetBooks");

//if (!response.IsSuccessStatusCode)
//{
//    Console.WriteLine(response.StatusCode);
//}
//else
//{
//    var content = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(JArray.Parse(content));
//}

using HelloRedis.Domain;
using HelloRedis.Repository;
using HelloRedis.RepositoryImp;
using System.Text.Json;

List<Book> BOOKS = new List<Book>();

BOOKS.Add(new Book { BookName="name1名字"});
BOOKS.Add(new Book { BookName = "name2" });
BOOKS.Add(new Book { BookName = "name3" });
BOOKS.Add(new Book { BookName = "name4" });
var text = JsonSerializer.Serialize(BOOKS);
Console.WriteLine(text);
var book2 = JsonSerializer.Deserialize<List<Book>>(text);
foreach (var item in book2)
{
    Console.WriteLine(item.BookName);
}
//System.DateTime startTime2 = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

//intResult = (DateTime.Now - startTime2).TotalSeconds;
//Console.WriteLine(intResult);
//startTime = startTime.AddSeconds(80);

//startTime = startTime.AddHours(8);
//Console.WriteLine(startTime);
//AbsDbcontext con = new SqlServerDbContext();


//con.Database.EnsureDeleted();
//con.Database.EnsureCreated();
//IBaseService<Author> baseService = new BaseSerivceImp<Author>(con);
//Author author = new Author { AuthorName = "张三11", BirthTime = DateTime.Now };
//con.Authors.Where(c => c.AuthorName == "sada").ToList() ;

//con.SaveChanges();
//Stock Stock = new Stock
//{
//    BookId = 3,
//    Count = 110,
//    UpdateTime = DateTime.Now,
//};
//Book book = new Book
//{
//    BookName = "test1",
//    ISBN = "isbn",
//    CreateTime = DateTime.Now,//2022/5/23 13:08:42
//    AuthorId = 1,
//};
//Console.WriteLine(book.CreateTime);
//con.Books.Add(book);

//con.Stocks.Add(Stock);
//con.SaveChanges();
//Author author = new Author
//{
//    AuthorName = "nam2",
//    BirthTime = DateTime.Now,

//};
//con.Authors.Add(author);
//con.SaveChanges();
// await baseService.CreateAsync(author);
//var au = await baseService.GetByIdAsync(6);
//au.AuthorName = "aaa";
//await baseService.PutEnityAsync(au);
//await baseService.CreateAsync(author);
//var lis = await baseService.QueryAsync(c => c.AuthorId > 3);
//foreach (var item in lis)
//{
//    Console.WriteLine(item.AuthorName);
//}
//IBaseService<Book> baseService = new BaseSerivceImp<Book>(con);
//Book book = new Book()
//{
//    ISBN ="ISBN",
//    BookName ="BookName",
//    Publisher = "Publisher",
//    AuthorId =1
//};
//await baseService.CreateAsync(book);


//await baseService.DeleteAsync(3);
//using RabbitMQ.Client;
//using Tools.RabbitMQ;
//using System.Text.Json;

//RabbitMQHelper helper = new RabbitMQHelper();

//Book book = new Book
//{
//    BookName = "Test",
//    ISBN = "ISBN",
//    CreateTime = DateTime.Now,
//    Publisher = "Publisher"
//};
//var test = JsonSerializer.Serialize(book);
//helper.Message = test;
//Console.WriteLine(helper.SendMessage());

//helper.GetMessage();
//foreach (var item in helper.ReciveMessage)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine(helper.ReciveMessage);

//Console.WriteLine(TimeSpan.FromMinutes(10).ToString());
//Console.WriteLine(TimeSpan.FromSeconds(10).ToString());

//Console.ReadLine();