using System.Threading.Tasks;

namespace HelloAbp.Data;

public interface IHelloAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
