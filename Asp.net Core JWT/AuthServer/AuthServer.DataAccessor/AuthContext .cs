using System;
using Microsoft.EntityFrameworkCore;


namespace AuthServer.DataAccessor
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {
        }

        public DbSet<AuthServer.Models.User> Users { get; set; }
    }
}
