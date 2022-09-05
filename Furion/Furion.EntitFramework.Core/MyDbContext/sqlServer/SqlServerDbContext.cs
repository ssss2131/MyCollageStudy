using Furion.Core.Locator;
using Furion.Core.Model;
using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furion.EntitFramework.Core.MyDbContext.sqlServer;
/// <summary>
/// 多数据库 sqllite sqlserver
/// 定位器继承于 IDbContextLocator接口 
/// 在startup中要加上相同的定位器
/// 
/// 多数据库迁移 Add-Migration [迁移名称] -Context [上下文类]
/// 更新数据库 Update-Database -Context [上下文类]
/// </summary>
[AppDbContext("sqlserverConnect", DbProvider.SqlServer)]

public class SqlServerDbContext : AppDbContext<SqlServerDbContext, SqlServerDbContextLocator>
{
    public DbSet<TestSqlServer>? TestSqlServer { get; set; }
    
    public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
    {
        InsertOrUpdateIgnoreNullValues = true;//Null时无需更新
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-RU9O3P7Q\MYSQL;Database=Furion;User=sa;Password=03012447;MultipleActiveResultSets=True;");
        base.OnConfiguring(optionsBuilder);
    }
}

