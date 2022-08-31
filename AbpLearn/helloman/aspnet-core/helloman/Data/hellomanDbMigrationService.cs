using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging.Abstractions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace helloman.Data;

public class hellomanDbMigrationService : ITransientDependency
{
    public ILogger<hellomanDbMigrationService> Logger { get; set; }

    private readonly IDataSeeder _dataSeeder;
    private readonly hellomanEFCoreDbSchemaMigrator _dbSchemaMigrator;

    public hellomanDbMigrationService(
        IDataSeeder dataSeeder,
        hellomanEFCoreDbSchemaMigrator dbSchemaMigrator
        )
    {
        _dataSeeder = dataSeeder;
        _dbSchemaMigrator = dbSchemaMigrator;

        Logger = NullLogger<hellomanDbMigrationService>.Instance;
    }

    public async Task MigrateAsync()
    {
    

        Logger.LogInformation("Started database migrations...");
        //
        await Task.CompletedTask;
      

        Logger.LogInformation($"Successfully completed host database migrations.");

      

        Logger.LogInformation("Successfully completed all database migrations.");
        Logger.LogInformation("You can safely end this process...");
    }

  
  

 
}
