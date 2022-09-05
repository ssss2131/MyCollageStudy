using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.EntitFramework.Core.MyDbContext.sqlLite;
[AppDbContext("SqlLiteConnect", DbProvider.Sqlite)]
public class AppDefaultContext : AppDbContext<AppDefaultContext>//AppDbContext 继承自 DbContext，具备 DbContext 所有功能。
{
    public AppDefaultContext(DbContextOptions<AppDefaultContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=./Furion.db");
        base.OnConfiguring(optionsBuilder);
    }
}

