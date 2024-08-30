using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Watchly.Data;

/* This is used if database provider does't define
 * IWatchlyDbSchemaMigrator implementation.
 */
public class NullWatchlyDbSchemaMigrator : IWatchlyDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
