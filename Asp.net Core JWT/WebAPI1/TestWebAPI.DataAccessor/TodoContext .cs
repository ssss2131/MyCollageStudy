using System;
using Microsoft.EntityFrameworkCore;


namespace TestWebAPI.DataAccessor
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TestWebAPI.Models.TodoItem> TodoItems { get; set; }
    }
}
