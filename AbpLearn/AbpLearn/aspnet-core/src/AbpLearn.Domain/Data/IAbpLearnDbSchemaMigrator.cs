using System.Threading.Tasks;

namespace AbpLearn.Data;

public interface IAbpLearnDbSchemaMigrator
{
    Task MigrateAsync();
}
