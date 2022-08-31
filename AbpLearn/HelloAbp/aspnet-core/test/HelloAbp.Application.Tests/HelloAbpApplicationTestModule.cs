using Volo.Abp.Modularity;

namespace HelloAbp;

[DependsOn(
    typeof(HelloAbpApplicationModule),
    typeof(HelloAbpDomainTestModule)
    )]
public class HelloAbpApplicationTestModule : AbpModule
{

}
