using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace MyFurionFilter.EntityFramework.Core
{
    [AppDbContext("MyFurionFilter", DbProvider.Sqlite)]
    public class DefaultDbContext : AppDbContext<DefaultDbContext>
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }
    }
}