using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace newsProject.Data;

/* This is used if database provider does't define
 * InewsProjectDbSchemaMigrator implementation.
 */
public class NullnewsProjectDbSchemaMigrator : InewsProjectDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
