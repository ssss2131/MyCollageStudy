using System.Threading.Tasks;

namespace newsProject.Data;

public interface InewsProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
