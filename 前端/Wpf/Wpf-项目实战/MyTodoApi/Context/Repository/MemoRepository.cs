using Microsoft.EntityFrameworkCore;
using MyTodoApi.Context.UnitOfWork;

namespace MyTodoApi.Context.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(ToDoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
