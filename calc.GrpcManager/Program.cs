using calc.Grpc;
using System;
using System.Threading.Tasks;

namespace calc.GrpcManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }


        static async Task MainAsync(string[] args)
        {
            var isServer = args[0].Equals("server");

            if (isServer)
            {
                var server = new CalcServerManager();
                server.Listen();
                Console.WriteLine("Listening...");
                Console.ReadKey();
                await server.ShutDownAsync();
            }
            else
            {
                Console.WriteLine("Please write formula for request");
                //String formula = "5 + ( ( 1 + 2 ) *  4 ) - 3";
                string formula = Console.ReadLine();
                var client = new CalcClientManager();
                client.Connect();
                Console.WriteLine(await client.SendMessageAsync(formula));

                await client.ShutDownAsync();
            }
        }
    }
}
