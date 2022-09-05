using Microsoft.EntityFrameworkCore;
using MyTodoApi.Context.UnitOfWork;

namespace MyTodoApi.Context.Repository
{
    public class TodoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public TodoRepository(ToDoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
