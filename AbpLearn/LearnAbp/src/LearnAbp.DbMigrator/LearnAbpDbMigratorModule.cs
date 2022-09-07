using LearnAbp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace LearnAbp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(LearnAbpEntityFrameworkCoreModule),
    typeof(LearnAbpApplicationContractsModule)
    )]
public class LearnAbpDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
