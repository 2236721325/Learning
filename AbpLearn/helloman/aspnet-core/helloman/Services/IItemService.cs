using Volo.Abp.Application.Services;

namespace helloman.Services
{
    public interface IItemService:IApplicationService
    {
        Task<Item> Get(int id);
    }
}
