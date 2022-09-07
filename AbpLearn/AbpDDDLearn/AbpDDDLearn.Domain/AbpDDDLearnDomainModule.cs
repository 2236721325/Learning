
using AbpDDDLearn.Domain.Shared;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace AbpDDDLearn.Domain
{
    [DependsOn(
     typeof(AbpDDDLearnDomainSharedModule),
             typeof(AbpDddDomainModule)
 )]
    public class AbpDDDLearnDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}