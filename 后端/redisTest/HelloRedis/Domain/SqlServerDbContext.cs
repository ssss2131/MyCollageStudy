using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    public class SqlServerDbContext:AbsDbcontext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=LAPTOP-RU9O3P7Q\MYSQL;Database=dbCore;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(c => {
                c.HasMany(b => b.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(p => p.AuthorId);
                c.Property(b => b.BirthTime)
                .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<Book>(c => {
                c.Property(c => c.CreateTime)
                .HasDefaultValueSql("getdate()");

            });
            modelBuilder.Entity<Stock>(c =>
            {
                c.HasOne(c => c.Book).WithOne().HasForeignKey<Stock>(P => P.BookId);
                c.Property(c => c.UpdateTime)
               .HasDefaultValueSql("getdate()");
            });
        }
    }
}
