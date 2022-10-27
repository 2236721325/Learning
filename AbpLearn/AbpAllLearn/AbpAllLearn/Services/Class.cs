using Volo.Abp.Application.Services;

namespace AbpAllLearn.Services
{
    public class FirstService:ApplicationService
    {
        public string SayHello()
        {
            return "Hello";
        }
    }
}
