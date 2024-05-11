
using System.ComponentModel.DataAnnotations;

namespace custos.Models
{
    public class DeviceDetails
    {
        [Key]
        public int Id { get; set; }
        public string? entity_type { get; set; } = string.Empty;
        public string? SubType { get; set; } = string.Empty;
        public long LastUpdateTime { get; set; }
        public string? DisplayLabel { get; set; } = string.Empty;
        public string? IpAddress { get; set; } = string.Empty;
        public string? MacAddress { get; set; } = string.Empty;
        public string? AgentVersion { get; set; } = string.Empty;
    }
	public class DeviceDetailsDto
	{
		[Key]
		public int Id { get; set; }
		
		public string? DisplayLabel { get; set; } = string.Empty;
		
	}
}
