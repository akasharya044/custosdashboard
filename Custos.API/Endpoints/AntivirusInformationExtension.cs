namespace custos.API.Endpoints
{
    public static partial class AntivirusInformationExtension
    {
        public static RouteGroupBuilder MapantivirusInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addantivirusInformation", AddAntivirusInformation);
            group.MapGet("/getantivirusInformation", GetAntivirusInformation);
            return group;

        }
    }
}

