using IdentityFirst.Data.MyModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityFirst.Data
{
    public class AppDbContext:IdentityDbContext<MyUser, IdentityRole, string>
    {
        public AppDbContext(DbContextOptions options):base(options)
        {
        }
    }
}
