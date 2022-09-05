using newsProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace newsProject;

[DependsOn(
    typeof(newsProjectEntityFrameworkCoreTestModule)
    )]
public class newsProjectDomainTestModule : AbpModule
{

}
