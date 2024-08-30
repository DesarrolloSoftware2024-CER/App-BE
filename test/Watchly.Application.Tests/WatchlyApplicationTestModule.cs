using Volo.Abp.Modularity;

namespace Watchly;

[DependsOn(
    typeof(WatchlyApplicationModule),
    typeof(WatchlyDomainTestModule)
)]
public class WatchlyApplicationTestModule : AbpModule
{

}
