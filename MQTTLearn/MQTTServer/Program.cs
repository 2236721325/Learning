using MQTTnet.Server;
using MQTTnet;
using MQTTnet.Protocol;
namespace MQTTServer
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            using (var myserver = new DemoMqttServer())
            {
                await myserver.StartAsync();
                while (true)
                {

                }
                await myserver.StopAsync();

            }
           

        }
    }

    public class DemoMqttServer:IDisposable
    {
        MqttServer _server;
        public DemoMqttServer()
        {
            var optionBuilder = new MqttServerOptionsBuilder()
                .WithDefaultEndpointPort(1883)
                .Build();
            _server = new MqttFactory().CreateMqttServer(optionBuilder);
            _server.ValidatingConnectionAsync += e =>
            {

                if (e.UserName != "*****"||e.Password!="*******")
                {
                    e.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                }

                return Task.CompletedTask;
            };
        }
        public async Task  StartAsync()
        {
           await _server.StartAsync();
        }
        public async Task StopAsync()
        {
            await _server.StopAsync();
        }
        

        public void Dispose()
        {
            ((IDisposable)_server).Dispose();
        }
    }
}
