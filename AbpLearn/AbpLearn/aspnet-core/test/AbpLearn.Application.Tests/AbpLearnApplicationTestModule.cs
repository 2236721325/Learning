using Volo.Abp.Modularity;

namespace AbpLearn;

[DependsOn(
    typeof(AbpLearnApplicationModule),
    typeof(AbpLearnDomainTestModule)
    )]
public class AbpLearnApplicationTestModule : AbpModule
{

}
