using System.Threading.Tasks;

namespace LearnAbp.Data;

public interface ILearnAbpDbSchemaMigrator
{
    Task MigrateAsync();
}
