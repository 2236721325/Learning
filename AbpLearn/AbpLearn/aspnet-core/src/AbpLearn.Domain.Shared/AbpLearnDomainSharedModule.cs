using AbpLearn.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.Validation.Localization;

namespace AbpLearn;

[DependsOn(
    typeof(AbpSettingManagementDomainSharedModule)
    )]
public class AbpLearnDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AbpLearnGlobalFeatureConfigurator.Configure();
        AbpLearnModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AbpLearnResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/AbpLearn");

            options.DefaultResourceType = typeof(AbpLearnResource);
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AbpLearn", typeof(AbpLearnResource));
        });
    }
}
