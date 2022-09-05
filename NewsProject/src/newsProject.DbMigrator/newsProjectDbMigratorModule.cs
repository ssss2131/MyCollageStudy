using newsProject.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace newsProject.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(newsProjectEntityFrameworkCoreModule),
    typeof(newsProjectApplicationContractsModule)
    )]
public class newsProjectDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
