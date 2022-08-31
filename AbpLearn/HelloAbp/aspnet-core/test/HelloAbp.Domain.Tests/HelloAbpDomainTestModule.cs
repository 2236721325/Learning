using HelloAbp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HelloAbp;

[DependsOn(
    typeof(HelloAbpEntityFrameworkCoreTestModule)
    )]
public class HelloAbpDomainTestModule : AbpModule
{

}
