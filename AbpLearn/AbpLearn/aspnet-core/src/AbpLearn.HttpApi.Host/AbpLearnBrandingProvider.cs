using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpLearn;

[Dependency(ReplaceServices = true)]
public class AbpLearnBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpLearn";
}
