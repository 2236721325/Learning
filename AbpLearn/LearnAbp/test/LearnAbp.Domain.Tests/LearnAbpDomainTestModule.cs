using LearnAbp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LearnAbp;

[DependsOn(
    typeof(LearnAbpEntityFrameworkCoreTestModule)
    )]
public class LearnAbpDomainTestModule : AbpModule
{

}
