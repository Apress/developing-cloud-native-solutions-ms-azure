using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Azure.Messaging.EventHubs;

namespace IoTHubEventProcessor
{
public class Function1
{
    private static HttpClient client = new HttpClient();
        
    [FunctionName("IoTHubEventProcessor")]
    public void Run(
        [IoTHubTrigger("iothub-ehub-my-sample-21753110-4a2f3a8272", Connection = "iotHubConn")]string message,
        [CosmosDB(
            databaseName:"mydb",
            collectionName:"PatientContianer",
            ConnectionStringSetting ="dbConn"
        )] IAsyncCollector<dynamic> documentsOut,
        ILogger log)
    {
        log.LogInformation($"C# IoT Hub trigger function processed a message: {message}");

        HealthModel data = JsonConvert.DeserializeObject<HealthModel>(message);

        documentsOut.AddAsync(
            new
            {
                id = data.Id,
                pulseRate = data.PluseRate,
                temprature = data.Temprature,
                recordedAt = data.RecordedAt
            }
            ).Wait();
    }
}
}