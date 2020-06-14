using Grpc.Net.Client;
using GrpcUsersService;
using System;

namespace GrpcUsersClient
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("gRPC Greet client");

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            Console.WriteLine($"Sending request to SayHallo method of Greet service ...");
            
            try
            {
                var reply = await client.SayHelloAsync(new HelloRequest { Name = "Josip" });

                Console.WriteLine($"Reply from server: " + reply.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while calling Grret service! " + ex.Message);
            }
            finally
            {
                channel.ShutdownAsync().Wait();
            }

            Console.ReadKey();
        }
    }
}
