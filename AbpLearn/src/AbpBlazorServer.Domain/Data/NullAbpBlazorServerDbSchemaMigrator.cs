using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpBlazorServer.Data;

/* This is used if database provider does't define
 * IAbpBlazorServerDbSchemaMigrator implementation.
 */
public class NullAbpBlazorServerDbSchemaMigrator : IAbpBlazorServerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
