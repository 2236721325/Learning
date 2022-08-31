using Volo.Abp.Application.Services;

namespace MiniAbp.Services
{
    public interface IItemService:IApplicationService
    {
        Task<string> Get();

        Task<string> Post(string he);
      
    }
}
