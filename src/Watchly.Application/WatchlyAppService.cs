using Watchly.Localization;
using Volo.Abp.Application.Services;

namespace Watchly;

/* Inherit your application services from this class.
 */
public abstract class WatchlyAppService : ApplicationService
{
    protected WatchlyAppService()
    {
        LocalizationResource = typeof(WatchlyResource);
    }
}
