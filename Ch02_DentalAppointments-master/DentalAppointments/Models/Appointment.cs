using System.ComponentModel.DataAnnotations;

namespace DentalAppointments.Models
{
    public class Appointment
    {
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public int PatientId { get; set; }
        [Required]
        public string? PatientName { get; set; }
        [Required]
        public string? PatientEmail { get; set; }
        [Required]
        public int CaretakerId { get; set; }
        [Required]
        public DateTime ScheduledAt { get; set; }
    }
}
