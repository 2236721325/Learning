using EmptyWebAbp.Shared;
using System.Diagnostics.Contracts;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Emailing;
using Volo.Abp.EventBus;

namespace EmptyWebAbp.Services.EventHandles
{
    public class LoginSucceedEventHandler
     : ILocalEventHandler<LoginSucceedEvent>,
        ITransientDependency
    {
        private readonly IEmailSender _EmailSender;

        public LoginSucceedEventHandler(IEmailSender emailSender)
        {
            _EmailSender = emailSender;
        }

        public async Task HandleEventAsync(LoginSucceedEvent eventData)
        {
            await _EmailSender.SendAsync(
                to: "2236721325@qq.com",
                subject: "来自某人的邮件",
                body: $"尊敬的{eventData.Name},您的账号注册成功！"
                ,false
                );
        }
    }
}
