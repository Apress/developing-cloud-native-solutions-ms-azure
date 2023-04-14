using Microsoft.Extensions.Azure;
using QueueProcessor.Business;

namespace QueueProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((host, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddAzureClients(builder
                        => builder.AddServiceBusClient(
                            host.Configuration.GetConnectionString("ServiceBus")
                            )
                        );
                    services.AddSingleton<IMailService, MailService>();
                })
                .Build();

            host.Run();
        }
    }
}