using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace helloman.Data;

public class hellomanEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public hellomanEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the hellomanDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<hellomanDbContext>()
            .Database
            .MigrateAsync();
    }
}
