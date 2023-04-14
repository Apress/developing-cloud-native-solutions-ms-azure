using Azure.Messaging.ServiceBus;
using DentalAppointments.Models;
using Newtonsoft.Json;

namespace DentalAppointments.Business
{
    public class NotificationBusiness : INotificationBusiness
    {
        public IConfiguration _configuration { get; set; }
        public ServiceBusClient _serviceBusClient { get; set; }
        public ServiceBusSender _serviceBusSender { get; set; }

        public NotificationBusiness(ServiceBusClient serviceBusClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _serviceBusClient = serviceBusClient;
            _serviceBusSender = _serviceBusClient.CreateSender(_configuration.GetValue<String>("queueName"));

        }
        public async Task<long> ScheduleAppointmentNotification(Appointment appointment)
        {
            //Serialize the appointment object
            String serializedContent = JsonConvert.SerializeObject(appointment);
            //Create a service bus message which contains the serialized appointment data  
            ServiceBusMessage serviceBusMessage = new ServiceBusMessage(serializedContent);

            var enqueueTime = appointment.ScheduledAt.AddHours(_configuration.GetValue<int>("enqueueDifference"));

            //Schedules the message in the service bus queue 
            var messageSequenceNumber = await _serviceBusSender
                .ScheduleMessageAsync(serviceBusMessage, enqueueTime);
            //Returns the message sequence number of the scheduled message in service bus queue
            return messageSequenceNumber;
        }

        public async Task CancelAppointmentNotification(long messageSequenceNumber)
        {
            await _serviceBusSender.CancelScheduledMessageAsync(messageSequenceNumber);
        }
    }
}
