using custos.Web.Components.Dto;

namespace custos.Web.Services
{
    public static class SessionState
    {
        public static DeviceDto Device { get; set; }=new DeviceDto { TotalDevices = 0, RunningDevices = 0 };
    }
}
