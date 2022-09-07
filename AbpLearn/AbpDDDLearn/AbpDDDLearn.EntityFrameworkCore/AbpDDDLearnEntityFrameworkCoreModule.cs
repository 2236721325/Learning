using AbpDDDLearn.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace AbpDDDLearn.EntityFrameworkCore
{
    [DependsOn(
     typeof(AbpDDDLearnDomainModule)
     )]
    [DependsOn(
    typeof(AbpEntityFrameworkCoreSqlServerModule)
     )]
    [DependsOn(
    typeof(AbpEntityFrameworkCoreModule)
     )]
    public class AbpDDDLearnEntityFrameworkCoreModule : AbpModule
    {


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MyDbContext>(options =>
            {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
                options.AddDefaultRepositories(includeAllEntities: true);
            });
            Configure<AbpDbContextOptions>(options =>
            {
                /* The main point to change your DBMS.
                 * See also LearnAbpMigrationsDbContextFactory for EF Core tooling. */
                options.UseSqlServer();
            });
        

        }
    }
}