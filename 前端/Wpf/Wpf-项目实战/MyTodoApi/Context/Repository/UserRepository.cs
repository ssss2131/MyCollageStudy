using Microsoft.EntityFrameworkCore;
using MyTodoApi.Context.UnitOfWork;

namespace MyTodoApi.Context.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(ToDoDbContext dbContext) : base(dbContext)
        {
        }
    }
}
