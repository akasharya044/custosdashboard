namespace custos.API.Endpoints
{
    public static partial class BackgroundThresholdExtension
    {
        public static RouteGroupBuilder MapBackgroundThresholdInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addBackgroundThresholdInformation", AddBackgroundThresholdInformation);
            group.MapGet("/getBackgroundThresholdInformation", GetBackgroundThresholdInformation);
            return group;

        }
    }
}
