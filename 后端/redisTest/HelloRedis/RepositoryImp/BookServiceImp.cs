using HelloRedis.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json;
using HelloRedis.Domain.Dto;
using HelloRedis.RepositoryImp;
using HelloRedis.Repository;

namespace HelloRedis.RepositoryImp
{
    public class BookServiceImp : IBooklService
    {
        private readonly AbsDbcontext Npgcontext;
        //private readonly RedisHelper  RedisContext;
        private string? Message=null;
        public BookServiceImp(AbsDbcontext context/*,RedisHelper redis*/)
        {
            Npgcontext = context;
            //RedisContext = redis;
        }
 
        public string DeleteBook(int bookId)
        {
            var book = Npgcontext.Books.Find(bookId);
            var res = "";
            if (book!=null)
            {               
                if (RedisHelper.GetString(bookId.ToString())!=null)
                {
                    RedisHelper.DeleteKey(bookId.ToString());
                }
                
                Npgcontext.Books.Remove(book);
                Npgcontext.SaveChanges();
                RedisHelper.DeleteListKey("bookList");
                Console.WriteLine("删除成功");
                RedisHelper.SetString(bookId.ToString(),JsonSerializer.Serialize(book));
                res = "删除成功";
                return res;
            }
            res = "删除发生了异常";
            Console.WriteLine("删除发生了异常");
            return res;
        }

        public Book GetBook(int bookId)
        {
            Book booK = new Book();
            if (RedisHelper.GetString(bookId.ToString()) == null)
            {
                var book = Npgcontext.Books.Find(bookId);
                booK = book;
                string json = JsonSerializer.Serialize(book);

                RedisHelper.SetString(bookId.ToString(), json);

                RedisHelper.TimeOut(bookId.ToString(),TimeSpan.FromMinutes(20));

                Console.WriteLine(RedisHelper.GetString(bookId.ToString()));
            }
            else
            {
                var bookStr = RedisHelper.GetString(bookId.ToString());
                booK = JsonSerializer.Deserialize<Book>(bookStr);
                //Console.WriteLine(RedisHelper.GetString(bookId.ToString()));
            }
            return booK;
           
        }

        public List<Book> GetBookList()
        {
           
            var redisBooks = RedisHelper.ListGet("bookList");
            List<Book> books = new List<Book>();
            if (redisBooks.Count() > 0)
            {
               
                foreach (var item in redisBooks)
                {
                    //Console.WriteLine(item);
                    books.Add(JsonSerializer.Deserialize<Book>(item.ToString()));
                }              
            }
            else
            { 
                var booksInDb = Npgcontext.Books.ToList();
                books = booksInDb;
                if (booksInDb != null)
                {
                    foreach (var item in booksInDb)
                    {
                        RedisHelper.ListPush("bookList", JsonSerializer.Serialize(item));
                        Console.WriteLine(item);
                    }
                  
                }
                else
                {
                    Console.WriteLine("数据库中没有数据");
                    return null;
                }             
            }
            return books;
        }

        public string PutBook(Book book)
        {
            var bookIn = Npgcontext.Books.Find(book.BookId);
            string res = "";
            if (bookIn != null)
            {
                bookIn.AuthorId = book.AuthorId;
                bookIn.BookName = book.BookName;
                //bookIn.CreateTime  = book.CreateTime;
                Npgcontext.Books.Update(bookIn);
                Npgcontext.SaveChanges();
                RedisHelper.DeleteListKey("bookList");
                RedisHelper.SetString(book.BookId.ToString(), JsonSerializer.Serialize(book));
                Console.WriteLine("修改成功");
                res = "修改成功";
            }
            else
            {
                Console.WriteLine("该书籍不存在");
                res = "修改失败";
            }
            return res;
                  
        }
        public Book CreateBook(CreateBookDto CreateBook)
        {
            Book book = new Book();
            book.AuthorId = CreateBook.AuthorId;
            book.BookName = CreateBook.BookName;
            Npgcontext.Books.Add(book);
            Npgcontext.SaveChanges();

            var redisbook = Npgcontext.Books.Where(c=>c.BookName.Equals(CreateBook.BookName)).First();

            RedisHelper.SetString(redisbook.BookId.ToString(), JsonSerializer.Serialize(redisbook));

            RedisHelper.DeleteListKey("bookList");
            return book;
        }
      
    }
}
