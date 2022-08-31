using AbpLearn.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpLearn;

[DependsOn(
    typeof(AbpLearnEntityFrameworkCoreTestModule)
    )]
public class AbpLearnDomainTestModule : AbpModule
{

}
