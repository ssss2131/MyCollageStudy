using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace Project1.EntityFramework.Core
{
    [AppDbContext("Project1", DbProvider.Sqlite)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}