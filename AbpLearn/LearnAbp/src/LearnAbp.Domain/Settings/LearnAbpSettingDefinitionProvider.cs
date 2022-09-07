using Volo.Abp.Settings;

namespace LearnAbp.Settings;

public class LearnAbpSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(LearnAbpSettings.MySetting1));
    }
}
