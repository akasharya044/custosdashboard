using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.Models
{
    public class DeviceRunningLog
    {
        [Key]
        public int Id { get; set; }
        public string SystemId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ShutDownTime { get; set; }

    }

    public class DeviceRunningLogDTO
    {

        public string SystemId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? ShutDownTime { get; set; }

    }
}
