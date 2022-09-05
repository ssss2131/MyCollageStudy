using ApiResource.Model;
using HelloRedis.Domain;
using HelloRedis.Domain.Dto;
using Presntation.Domain.Service;
using Presntation.Domain;
using HelloRedis.RepositoryImp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Dto;

namespace ApiResource.Controllers
{
    [Route("Books/[action]")]
    [ApiController]
    //[Authorize]
    public class GetController : ControllerBase
    {
        private readonly IBookService m_IBookService;
        public GetController(IBookService BookService)
        {
            m_IBookService = BookService;
        }
        [HttpGet]
        public async Task<IActionResult> ShowBooks()
        {
           var books =  await m_IBookService.QueryAsync();
            return new JsonResult(books);
        }
        [HttpGet]
        public async Task<IActionResult> ShowBook(int id)
        { 
            var book = await m_IBookService.QueryOne(c=>c.BookId == id);
            return new JsonResult(book);
        }
        [HttpPut]
        public async Task<IActionResult> ChangeBook(ChangeBookViewModel model)
        {
            var book = await m_IBookService.GetByIdAsync(model.BookId);
            if (book == null)
            {
                return new JsonResult("书本信息不存在,无法修改");
            }
            book.BookName = model.BookName;
            book.ISBN = model.ISBN;
            book.Publisher = model.Publisher;
            return new JsonResult(await m_IBookService.PutEnityAsync(book));
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveABook(int bookId)
        {
            return new JsonResult(await m_IBookService.DeleteAsync(bookId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateABook(CreateBookModel creatBook)
        {
            var book = new Book();
            book.BookName = creatBook.BookName;
            book.ISBN = creatBook.ISBN;
            book.CreateTime = DateTime.Now;
            book.AuthorId = creatBook.AuthorId;
            return new JsonResult(await m_IBookService.CreateAsync(book));
        }
    }
}
