using EfRelation.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRelation.AppDbContext
{
    public class MyDbContext:DbContext
    {
        public DbSet<Student>? Student { get; set; }
        public DbSet<Teacher>? Teacher { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-RU9O3P7Q\MYSQL;Database=EFGetStarted.ConsoleApp.NewDb;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }
}
