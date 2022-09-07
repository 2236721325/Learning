using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace LearnAbp.Web;

[Dependency(ReplaceServices = true)]
public class LearnAbpBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "LearnAbp";
}
