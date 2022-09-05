using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRedis.Domain
{
    //postgrelDbContext
    public class AppDbContext:AbsDbcontext
    {
        public override int SaveChanges()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            SetSystemField();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
            SetSystemField();
            return base.SaveChangesAsync();
        }
        /// <summary>
        /// 系统字段赋值
        /// </summary>
        private void SetSystemField()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is Stock)
                {
                    var entity = (Stock)item.Entity;
                    ////添加操作
                    //if (item.State == EntityState.Added)
                    //{
                    //    if (entity.Id == Guid.Empty)
                    //    {
                    //        entity.Id = Guid.NewGuid();
                    //    }
                    //    entity.CreateTime = DateTime.Now;
                    //    entity.ModifiedTime = DateTime.Now;
                    //}
                    //修改操作
                    if (item.State == EntityState.Modified)
                    {
                        entity.UpdateTime = DateTime.UtcNow;
                    }
                }

            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Blog)
                .WithMany(b => b.Posts)
                .HasForeignKey(p => p.BlogUrl)
                .HasPrincipalKey(b => b.Url);
            modelBuilder.Entity<Person>()
                .Property(p => p.LastUpdated)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);

            modelBuilder.Entity<Author>(c => {
                c.HasMany(b => b.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(p => p.AuthorId);
                c.Property(b => b.BirthTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
               
            });
            modelBuilder.Entity<Book>(c => {
                c.Property(c => c.CreateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
               
            });
            modelBuilder.Entity<Stock>(c => 
            {
                c.HasOne(c=>c.Book).WithOne().HasForeignKey<Stock>(P => P.BookId);
                c.Property(c => c.UpdateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql("Host=localhost;Port=5432;Database=Microsoft-Learn-Model-TypeAndProperty;Username=postgres;Password=03012447;");
        }
      
    }
}
