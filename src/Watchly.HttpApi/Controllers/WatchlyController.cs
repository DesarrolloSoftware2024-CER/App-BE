using Watchly.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Watchly.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class WatchlyController : AbpControllerBase
{
    protected WatchlyController()
    {
        LocalizationResource = typeof(WatchlyResource);
    }
}
