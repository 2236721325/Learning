using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace helloman.Services
{
    public class ItemService : ApplicationService, IItemService
    {
        private readonly IRepository<Item, int> _Repository;

        public ItemService(IRepository<Item, int> repository)
        {
            _Repository = repository;
        }

        public async Task<Item> Get(int id)
        {
            return await _Repository.GetAsync(id);
        }
    }

    public class Item:BasicAggregateRoot<int>
    {
        public string Name { get; set; }
    }
}
