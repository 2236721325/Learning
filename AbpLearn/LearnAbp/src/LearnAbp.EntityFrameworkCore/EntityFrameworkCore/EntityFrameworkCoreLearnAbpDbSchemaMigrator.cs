using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LearnAbp.Data;
using Volo.Abp.DependencyInjection;

namespace LearnAbp.EntityFrameworkCore;

public class EntityFrameworkCoreLearnAbpDbSchemaMigrator
    : ILearnAbpDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreLearnAbpDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the LearnAbpDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<LearnAbpDbContext>()
            .Database
            .MigrateAsync();
    }
}
