namespace custos.API.Endpoints
{
    public static partial class OperatingSystemExtension
    {
        public static RouteGroupBuilder MapOperatingSystemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addOperatingSystemInformation", AddOperatingSystemInformation);
            group.MapGet("/getOperatingSystemInformation", GetOperatingSystemInformation);
            return group;

        }
    }
}
