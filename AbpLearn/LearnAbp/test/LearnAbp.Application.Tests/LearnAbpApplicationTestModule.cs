using Volo.Abp.Modularity;

namespace LearnAbp;

[DependsOn(
    typeof(LearnAbpApplicationModule),
    typeof(LearnAbpDomainTestModule)
    )]
public class LearnAbpApplicationTestModule : AbpModule
{

}
