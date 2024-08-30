using System.Threading.Tasks;

namespace Watchly.Data;

public interface IWatchlyDbSchemaMigrator
{
    Task MigrateAsync();
}
