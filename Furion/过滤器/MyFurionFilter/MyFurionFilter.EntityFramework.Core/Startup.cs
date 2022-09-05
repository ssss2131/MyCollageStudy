using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace MyFurionFilter.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<DefaultDbContext>();
            }, "MyFurionFilter.Database.Migrations");
        }
    }
}