using Volo.Abp.Modularity;

namespace Watchly;

[DependsOn(
    typeof(WatchlyDomainModule),
    typeof(WatchlyTestBaseModule)
)]
public class WatchlyDomainTestModule : AbpModule
{

}
