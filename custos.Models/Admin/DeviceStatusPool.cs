using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models
{
    public class DeviceStatusPool
    {
        public string DeviceId { get; set; }
        public DateTime LastHeartBeat { get; set; }
        public bool IsRunning { get; set; } = false;
    }
}
