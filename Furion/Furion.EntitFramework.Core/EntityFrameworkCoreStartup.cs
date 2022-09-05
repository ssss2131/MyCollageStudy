using Furion.DatabaseAccessor;
using Furion.EntitFramework.Core.Locator;
using Furion.EntitFramework.Core.MyDbContext.sqlLite;
using Furion.EntitFramework.Core.MyDbContext.sqlServer;
using Microsoft.Extensions.DependencyInjection;


namespace Furion.EntitFramework.Core;


[AppStartup(600)]
public class EntityFrameworkCoreStartup:AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // 配置数据库上下文，支持N个数据库
        services.AddDatabaseAccessor(options =>
        {
            // 配置默认数据库
            options.AddDbPool<AppDefaultContext>(DbProvider.Sqlite);
            // 配置多个数据库，多个数据库必须指定数据库上下文定位器
            //  options.AddDbPool<SqliteDbContext, SqliteDbContextLocaotr>();
            options.AddDbPool<SqlServerDbContext, SqlServerDbContextLocator>(DbProvider.SqlServer);
        },"Furion.EntityFrameworkCore.MyMigration");
    }
}

