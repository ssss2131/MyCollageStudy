using Volo.Abp.Modularity;

namespace newsProject;

[DependsOn(
    typeof(newsProjectApplicationModule),
    typeof(newsProjectDomainTestModule)
    )]
public class newsProjectApplicationTestModule : AbpModule
{

}
