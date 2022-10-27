using Abp从0搭建授权中心.Datas;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;

namespace Abp从0搭建授权中心.Services
{
    public class SeedService : ApplicationService
    {
        private readonly IDataSeeder _DataSeeder;

        public SeedService(IDataSeeder dataSeeder)
        {
            _DataSeeder = dataSeeder;
        }
        public async Task<bool> SeedData()
        {
            await _DataSeeder.SeedAsync();
            return true;
        }
    }
}
