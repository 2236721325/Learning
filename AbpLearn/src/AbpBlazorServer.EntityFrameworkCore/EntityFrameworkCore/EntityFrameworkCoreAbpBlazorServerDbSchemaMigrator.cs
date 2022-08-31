using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpBlazorServer.Data;
using Volo.Abp.DependencyInjection;

namespace AbpBlazorServer.EntityFrameworkCore;

public class EntityFrameworkCoreAbpBlazorServerDbSchemaMigrator
    : IAbpBlazorServerDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAbpBlazorServerDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the AbpBlazorServerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AbpBlazorServerDbContext>()
            .Database
            .MigrateAsync();
    }
}
