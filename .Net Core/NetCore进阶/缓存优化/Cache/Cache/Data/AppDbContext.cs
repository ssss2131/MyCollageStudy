using Cache.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cache.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<Numbers>? MyNumbers { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
               
        }
    }
}
