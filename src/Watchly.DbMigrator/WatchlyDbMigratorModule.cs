using Watchly.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Watchly.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(WatchlyEntityFrameworkCoreModule),
    typeof(WatchlyApplicationContractsModule)
)]
public class WatchlyDbMigratorModule : AbpModule
{
}
