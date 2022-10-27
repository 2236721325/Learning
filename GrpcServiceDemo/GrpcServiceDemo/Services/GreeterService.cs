using Grpc.Core;
using GrpcServiceDemo;

namespace GrpcServiceDemo.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;
        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
        public override Task<YesReply> SayYes(YesRequest request, ServerCallContext context)
        {
            return Task.FromResult(new YesReply()
            {
                Str = "������磡"
            });
        }

    }
}