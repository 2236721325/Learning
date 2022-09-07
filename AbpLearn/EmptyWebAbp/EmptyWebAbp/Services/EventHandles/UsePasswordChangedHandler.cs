using EmptyWebAbp.Shared;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;

namespace EmptyWebAbp.Services.EventHandles
{
    public class UsePasswordChangedHandler
       : ILocalEventHandler<UserPasswordChangedEvent>,
       ITransientDependency

    {
        public async Task HandleEventAsync(UserPasswordChangedEvent eventData)
        {
            Console.WriteLine("你好1233"); 

            await Task.CompletedTask;
        }
    }
}
