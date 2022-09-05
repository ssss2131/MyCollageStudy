using HelloRedis;
using HelloRedis.Domain;
using StackExchange.Redis;
using Npgsql;
using HelloRedis.Repository;
using IdentityModel.Client;
using Newtonsoft.Json.Linq;
#region Test
//RedisHelper.SetString("String-key","String-value");
//RedisHelper.GetString("String-key");

//RedisHelper.ListPush("List-key", "list-value1");
//RedisHelper.ListPush("List-key", "list-value2");

//RedisHelper.ListGet("List-key");

//RedisHelper.SetIn("Set-key", "Set-value1");
//RedisHelper.SetIn("Set-key", "Set-value2");

//RedisHelper.SetGet("Set-key");

//RedisHelper.HashAdd("Hash-key", "Hash-keyName1", "Hash-value1");
//RedisHelper.HashAdd("Hash-key", "Hash-keyName2", "Hash-value2");

//RedisHelper.GetHash("Hash-key");

//TimeSpan t = TimeSpan.FromSeconds(5);
//RedisHelper.TimeOut("String-key", t);

//AppDbContext con = new AppDbContext();
//con.Database.EnsureDeleted();
//con.Database.EnsureCreated();


//IBooklService bs = new BookServiceImp(con);
//bs.GetBook(1);
//bs.GetBook(9);
//bs.DeleteBook(7);

//Book b = new Book
//{
//    BookId = 10,
//    AuthorId = 1,
//    BookName = "UpdateName",
//    CreateTime = DateTime.Now,
//};
//bs.PutBook(b);
//bs.GetBookList();
//RedisHelper.SetString("Message", "N");

//Person p = new Person
//{   Id = 1,
//    FirstName ="Tom2",
//    LastName ="Simith2"
//};
//var p2 = con.Persons.Find(p.Id);
//p2.FirstName = p.FirstName;
//p2.LastName = p.LastName;
//con.Persons.Update(p2);

//con.SaveChanges();
#endregion

#region Api
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
//    Scope ="api1"//email无效 因为ClientCredential不代表任何用户 但email等信息代表的使用户 请求不合理
//});

//if (tokenResponse.IsError)
//{
//    Console.WriteLine(tokenResponse.Error);
//    return;
//}

//Console.WriteLine(tokenResponse.Json);

//var response = await client.GetAsync("https://localhost:7130/Identity");
//if (!response.IsSuccessStatusCode)
//{
//    Console.WriteLine(response.StatusCode);
//}
//else
//{
//    var content = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(JArray.Parse(content));
//}
#endregion