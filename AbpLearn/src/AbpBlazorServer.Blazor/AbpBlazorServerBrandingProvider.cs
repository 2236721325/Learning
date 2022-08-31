using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpBlazorServer.Blazor;

[Dependency(ReplaceServices = true)]
public class AbpBlazorServerBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpBlazorServer";
}
