using Volo.Abp.Modularity;
using Volo.Abp.Validation;

namespace AbpDDDLearn.Domain.Shared
{
    [DependsOn(
          typeof(AbpValidationModule)
     )]
    public class AbpDDDLearnDomainSharedModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {

        }
    }
}