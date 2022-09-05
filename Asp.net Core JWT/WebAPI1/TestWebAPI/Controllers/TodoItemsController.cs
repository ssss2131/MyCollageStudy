using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Models;

namespace TestWebAPI1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        private static TestWebAPI.DataAccessor.TodoContext m_DbContext;

        private static bool m_Init = false;
        private static void Init()
        {
            if (!m_Init)
            {
                m_DbContext.TodoItems.Add(new TodoItem
                {
                    Name = "计划工作A-WebAPI-1",
                    IsComplete = false
                });
                m_DbContext.SaveChanges();

                m_Init = true;
            }
        }

        public TodoItemsController(TestWebAPI.DataAccessor.TodoContext dbContext)
        {
            m_DbContext = dbContext;
            Init();
        }

        // GET: api/TodoItems
        //[HttpGet("items")]
        [Authorize]
        [HttpGet()]
        public ActionResult<IQueryable<TodoItem>> GetTodoItem()
        {
            var todoItems = m_DbContext.TodoItems;

            if (todoItems == null)
            {
                return NotFound();
            }

            return todoItems;
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id,string e)
        {
            var todoItem = await m_DbContext.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }


    }
}
