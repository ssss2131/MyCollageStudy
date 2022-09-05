using Furion;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace VoteSystem.EntityFramework.Core
{
    [AppDbContext("VoteSystem", DbProvider.SqlServer)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
            InsertOrUpdateIgnoreNullValues = true;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-RU9O3P7Q\MYSQL;Database=Furion;User=sa;Password=03012447;MultipleActiveResultSets=True;");
           
        }

    }
}