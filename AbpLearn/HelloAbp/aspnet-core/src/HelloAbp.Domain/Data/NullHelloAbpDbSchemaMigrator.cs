using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HelloAbp.Data;

/* This is used if database provider does't define
 * IHelloAbpDbSchemaMigrator implementation.
 */
public class NullHelloAbpDbSchemaMigrator : IHelloAbpDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
