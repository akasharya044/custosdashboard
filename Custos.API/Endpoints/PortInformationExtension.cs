namespace custos.API.Endpoints
{
    public static partial class PortInformationExtension
    {
        public static RouteGroupBuilder MapPortInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addportInformation", AddPortInformation);
            group.MapGet("/getportInformation", GetPortInformation);
            group.MapGet("/getportInformationById", GetPortById);


            return group;

        }
    }
}
