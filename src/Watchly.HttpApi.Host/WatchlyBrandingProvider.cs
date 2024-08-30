using Microsoft.Extensions.Localization;
using Watchly.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Watchly;

[Dependency(ReplaceServices = true)]
public class WatchlyBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<WatchlyResource> _localizer;

    public WatchlyBrandingProvider(IStringLocalizer<WatchlyResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
