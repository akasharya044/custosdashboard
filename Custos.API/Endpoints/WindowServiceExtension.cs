namespace custos.API.Endpoints
{
    public static partial class WindowServiceExtension
    {
        public static RouteGroupBuilder MapWindowServicesInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addwindowServiceInformation", AddWindowServicesInformation);
            group.MapGet("/getwindoeServiceInformation", GetWindowServicesInformation);
            group.MapGet("/getwindoeServiceInformationById", GetWindowServicesInformationById);

            return group;

        }
    }
}
