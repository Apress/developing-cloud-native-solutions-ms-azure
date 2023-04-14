using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTHubEventProcessor
{
    public class HealthModel
    {
        public string Id { get; set; }
        public int PluseRate { get; set; }
        public int Temprature { get; set; }
        public DateTime RecordedAt { get; set; }
    }
}
