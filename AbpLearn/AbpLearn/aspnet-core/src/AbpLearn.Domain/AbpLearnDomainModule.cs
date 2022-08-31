using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.AuditLogging;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace AbpLearn;

[DependsOn(
    typeof(AbpLearnDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
  
    typeof(AbpSettingManagementDomainModule)
)]
public class AbpLearnDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
      

    }
}
