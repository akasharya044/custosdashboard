namespace custos.API.Endpoints
{
    public static partial class OSCoreExtension
    {
        public static RouteGroupBuilder MapOSCoreInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addoscoreInformation", AddOSCoreInformation);
            group.MapGet("/getoscoreInformation", GetOSCoreInformation);
            return group;

        }
    }
}
