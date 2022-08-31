using Volo.Abp.Application.Services;

namespace MiniAbp.Services
{
    public class ItemService:ApplicationService, IItemService
    {
        public Task<string> Get()
        {
            return Task.FromResult("hello");
        }
        public Task<string> Post(string he)
        {
            return Task.FromResult(he);
        }
    }
}
