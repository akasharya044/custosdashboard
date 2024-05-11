
using System.ComponentModel.DataAnnotations;

namespace custos.Models
{
    public class DeviceDailyStatus
    {
        [Key]
        public int Id { get; set; }
        public string SystemId { get; set; }
        public DateTime LastLoginTime { get; set; }
    }
}
