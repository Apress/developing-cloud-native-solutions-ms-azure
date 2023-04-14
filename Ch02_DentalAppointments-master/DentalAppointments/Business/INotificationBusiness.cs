using DentalAppointments.Models;

namespace DentalAppointments.Business
{
    public interface INotificationBusiness
    {
         public Task<long> ScheduleAppointmentNotification(Appointment appointment);
         public Task CancelAppointmentNotification(long id);
    }
}
