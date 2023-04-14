using QueueProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueProcessor.Business
{
    public interface IMailService
    {
        void SendEmail(Appointment appointment);
    }
}
