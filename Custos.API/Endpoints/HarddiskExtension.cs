namespace custos.API.Endpoints
{
    public static partial class HarddiskExtension
    {
        public static RouteGroupBuilder MapHarddiskInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addharddiskInformation", AddHarddiskInformation);
            group.MapGet("/getharddiskInformation", GetHarddiskInformation);
            return group;

        }
    }
}

