using Microsoft.EntityFrameworkCore;

namespace MyTodoApi.Context
{
    public class ToDoDbContext:DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options):base(options)
        {

        }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Memo> Memos { get; set; }
    }
}
