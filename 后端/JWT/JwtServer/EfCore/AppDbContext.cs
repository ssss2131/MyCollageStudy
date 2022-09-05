using JwtServer.Model;
using Microsoft.EntityFrameworkCore;

namespace JwtServer.EfCore
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<User>? Users { get; set; }

       
    }
}
