using Volo.Abp.Modularity;

namespace Watchly;

public abstract class WatchlyApplicationTestBase<TStartupModule> : WatchlyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
