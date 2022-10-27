using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace AbpSomeModuleLearns.Services
{
    [Authorize("Insert")]
    public class AuthorAppService : ApplicationService
    {
        public async Task<string> GetHelloString()
        {
            await Task.CompletedTask;
            return "Hello";
        }
      
    }
}
