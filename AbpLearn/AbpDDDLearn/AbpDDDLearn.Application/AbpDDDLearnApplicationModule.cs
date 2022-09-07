using AbpDDDLearn.Application.Contracts;
using AbpDDDLearn.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace AbpDDDLearn.Application
{
    [DependsOn(
    typeof(AbpDDDLearnDomainModule),
    typeof(AbpDDDLearnApplicationContractsModule),
    typeof(AbpAutoMapperModule)

    )]
    public class AbpDDDLearnApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AbpDDDLearnApplicationModule>();
            });
            Configure<AbpSequentialGuidGeneratorOptions>(options =>
            {
                options.DefaultSequentialGuidType = SequentialGuidType.SequentialAtEnd;
            });
        }
    }
}