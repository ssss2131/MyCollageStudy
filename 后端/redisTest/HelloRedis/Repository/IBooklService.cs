using HelloRedis.Domain;
using HelloRedis.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Repository
{
    public interface IBooklService
    {
        List<Book> GetBookList();
        Book GetBook(int bookId);
        string PutBook(Book book);

        string DeleteBook(int bookId);
        Book CreateBook(CreateBookDto createBook);
    }
}
