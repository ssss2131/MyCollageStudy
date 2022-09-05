using Microsoft.Extensions.Internal;
using ShopStoreCore.System.Provicy;
using System.Security.AccessControl;

namespace StoreEfCore;

public class AppDbContext: DbContext
{
    public DbSet<SystemUser>? SystemUser { get; set; }
    public DbSet<SystemGoods>? SystemGoods { get; set; }
    public DbSet<SystemGoodsRecord>? SystemGoodsRecord { get; set; }
    public DbSet<SystemMenu>? SystemMenu { get; set; }
    public DbSet<SystemRole>? SystemRole { get; set; }
    public DbSet<SystemOperation>? SystemOperation { get; set; }
    public DbSet<SystemOpRole>? SystemOpRole { get; set; }
    public AppDbContext(DbContextOptions options):base(options)
    {
      
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-RU9O3P7Q\\MYSQL;Database=MyStore;Trusted_Connection=True;");
        base.OnConfiguring(optionsBuilder);
    }

}
