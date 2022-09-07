using EmptyWebAbp.Shared;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace EmptyWebAbp.Services.EventHandles
{
    public class UsePasswordChangedDistributeHandler
     : IDistributedEventHandler<UserPasswordChangedEvent>,
     ITransientDependency

    {
        public async Task HandleEventAsync(UserPasswordChangedEvent eventData)
        {
            Console.WriteLine("你好1233");

            await Task.CompletedTask;
        }
    }
}
