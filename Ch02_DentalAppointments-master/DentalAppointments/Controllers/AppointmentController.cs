using DentalAppointments.Business;
using DentalAppointments.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DentalAppointments.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        public INotificationBusiness _notificationBusiness { get; set; }
        public AppointmentController(INotificationBusiness notificationBusiness)
        {
            _notificationBusiness = notificationBusiness;
        }


        [HttpPost("Notification/Schedule")]
        public async Task<IActionResult> ScheduledAppointmentNotificationInQueue([FromBody] Appointment appointment)
        {
            try
            {
                long msgSequenceNumber = await _notificationBusiness.ScheduleAppointmentNotification(appointment);

                return new OkObjectResult(new { MessageSequenceNumber = msgSequenceNumber });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("Notification/Cancel/{messageSequenceNumber:long}")]
        public async Task<IActionResult> CancelAppointmentNotificationFromQueue([FromRoute] int messageSequenceNumber)
        {
            try
            {
                if (messageSequenceNumber < 0)
                {
                    return new BadRequestObjectResult("Invalid value of messageSequenceNumber");
                }
                await _notificationBusiness.CancelAppointmentNotification(messageSequenceNumber);
                return new OkObjectResult("Scheduled message has been discarded.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
