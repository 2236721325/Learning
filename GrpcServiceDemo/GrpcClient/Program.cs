using Grpc.Net.Client;
using GrpcServiceDemo;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // The port number must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("http://localhost:5155");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayYesAsync(
                              new YesRequest());

            Console.WriteLine("Greeting: " + reply.Str);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}