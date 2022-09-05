using Volo.Abp.Settings;

namespace newsProject.Settings;

public class newsProjectSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(newsProjectSettings.MySetting1));
    }
}
