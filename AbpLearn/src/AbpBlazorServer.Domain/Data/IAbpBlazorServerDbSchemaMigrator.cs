using System.Threading.Tasks;

namespace AbpBlazorServer.Data;

public interface IAbpBlazorServerDbSchemaMigrator
{
    Task MigrateAsync();
}
