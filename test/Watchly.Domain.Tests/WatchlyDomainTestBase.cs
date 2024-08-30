using Volo.Abp.Modularity;

namespace Watchly;

/* Inherit from this class for your domain layer tests. */
public abstract class WatchlyDomainTestBase<TStartupModule> : WatchlyTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
