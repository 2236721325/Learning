using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LearnAbp.Data;

/* This is used if database provider does't define
 * ILearnAbpDbSchemaMigrator implementation.
 */
public class NullLearnAbpDbSchemaMigrator : ILearnAbpDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
