using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace Project1.EntityFramework.Core
{
    public class Startup : AppStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDatabaseAccessor(options =>
            {
                options.AddDbPool<DefaultDbContext>();
            }, "Project1.Database.Migrations");
        }
    }
}