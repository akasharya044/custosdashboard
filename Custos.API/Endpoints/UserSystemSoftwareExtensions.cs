namespace Custos.API.Endpoints
{
    public static partial class UserSystemSoftwareExtension
    {
        public static RouteGroupBuilder MapSystemInfoEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addsoftwareinfo", UserSystemSoftware);
            group.MapGet("/getsoftwareinfo", GetUserSystemSoftware);
            group.MapPost("/addhardwareinfo", AddSystemHardware);
            group.MapGet("/gethardwareinfo", GetallHardware);
            group.MapGet("/gethardwarebyuserid", GetHardwareByUserId);
            group.MapGet("getsoftwarebyuserid", GetSoftwareByUserId);
            return group;
        }
    }
}
