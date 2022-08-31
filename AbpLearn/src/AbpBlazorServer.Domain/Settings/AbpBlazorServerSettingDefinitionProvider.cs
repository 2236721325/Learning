using Volo.Abp.Settings;

namespace AbpBlazorServer.Settings;

public class AbpBlazorServerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(AbpBlazorServerSettings.MySetting1));
    }
}
