using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using QueueProcessor.Business;
using QueueProcessor.Models;

namespace QueueProcessor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ServiceBusClient _sbClient;
        private readonly ServiceBusReceiver _receiver;
        private readonly IMailService _mailService;

        public Worker(ILogger<Worker> logger, ServiceBusClient serviceBusClient, IConfiguration configuration, IMailService mailService)
        {
            _logger = logger;
            _sbClient = serviceBusClient;
            _receiver = _sbClient.CreateReceiver(configuration.GetValue<String>("queueName"));
            _mailService = mailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _logger.LogInformation($"FullyQualifiedNamespace is {_receiver.FullyQualifiedNamespace}");
                try
                {
                    var message = await _receiver.ReceiveMessageAsync();
                    while (message != null)
                    {
                        _logger.LogInformation(message.Body.ToString());
                        Appointment? data = JsonConvert.DeserializeObject<Appointment>(message.Body.ToString());
                        if (data == null)
                        {
                            _logger.LogError("Message content was null");
                        }
                        if (String.IsNullOrWhiteSpace(data.PatientEmail))
                        {
                            _logger.LogError("Patient's email does not exist in the payload.");
                        }
                        _mailService.SendEmail(data);
                        await _receiver.CompleteMessageAsync(message);
                        message = await _receiver.ReceiveMessageAsync();
                    }
                    _logger.LogInformation("Waiting for 2 mins now.");
                    await Task.Delay(120000);

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }
        }
    }
}