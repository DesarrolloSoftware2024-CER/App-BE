using Volo.Abp.Settings;

namespace Watchly.Settings;

public class WatchlySettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(WatchlySettings.MySetting1));
    }
}
