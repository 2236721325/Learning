using HelloAbp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace HelloAbp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HelloAbpEntityFrameworkCoreModule),
    typeof(HelloAbpApplicationContractsModule)
    )]
public class HelloAbpDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
