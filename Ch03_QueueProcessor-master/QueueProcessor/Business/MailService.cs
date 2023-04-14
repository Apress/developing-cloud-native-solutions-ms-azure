using QueueProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QueueProcessor.Business
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(Appointment appointment)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(appointment.PatientEmail);
            mail.Subject = $"You have a appointment scheduled at {appointment.ScheduledAt.ToString("g")}";
            mail.Body = $"<p>Hello there {appointment.PatientName}!" +
                $"<br /><br />You have a dental appointment scheduled at {appointment.ScheduledAt.ToString("g")}." +
                $"<br /><br />Thanks" +
                $"<br />Ashirwad</p>";
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(_configuration.GetValue<String>("emailId"));

            using (var smtpClient = new SmtpClient())
            {
                smtpClient.Host = _configuration.GetValue<string>("host");
                smtpClient.Port = _configuration.GetValue<int>("port");
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(_configuration.GetValue<String>("emailId"), _configuration.GetValue<String>("AppPwd"));
                smtpClient.Send(mail);
            }
        }

    }
}
