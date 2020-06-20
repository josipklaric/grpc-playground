using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcDemo;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== gRPC demo client ===");
            
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);

            Console.WriteLine($"Sending request to Greet service ...");

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Josip" });

            Console.WriteLine($"Reply from server: " + reply.Message);

            //Console.ReadKey();
        }
    }
}
