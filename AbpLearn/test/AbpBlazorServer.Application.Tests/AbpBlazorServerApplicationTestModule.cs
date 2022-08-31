using Volo.Abp.Modularity;

namespace AbpBlazorServer;

[DependsOn(
    typeof(AbpBlazorServerApplicationModule),
    typeof(AbpBlazorServerDomainTestModule)
    )]
public class AbpBlazorServerApplicationTestModule : AbpModule
{

}
