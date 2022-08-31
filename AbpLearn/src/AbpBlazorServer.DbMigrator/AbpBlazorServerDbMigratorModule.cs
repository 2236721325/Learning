using AbpBlazorServer.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpBlazorServer.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpBlazorServerEntityFrameworkCoreModule),
    typeof(AbpBlazorServerApplicationContractsModule)
    )]
public class AbpBlazorServerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
