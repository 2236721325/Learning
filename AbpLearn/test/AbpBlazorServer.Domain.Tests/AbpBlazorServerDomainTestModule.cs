using AbpBlazorServer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpBlazorServer;

[DependsOn(
    typeof(AbpBlazorServerEntityFrameworkCoreTestModule)
    )]
public class AbpBlazorServerDomainTestModule : AbpModule
{

}
