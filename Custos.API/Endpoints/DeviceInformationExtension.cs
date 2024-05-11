using System.Text.RegularExpressions;

namespace custos.API.Endpoints
{
    public static partial class DeviceInformationExtension
    {
        public static RouteGroupBuilder MapDeviceInformationEndpoint(this RouteGroupBuilder group) 
        {
            group.MapPost("/adddeviceInformation",AddDeviceInformation);
            group.MapGet("/getdeviceInformation",GetDeviceInformation);
            return group;
        
        }
    }
}
