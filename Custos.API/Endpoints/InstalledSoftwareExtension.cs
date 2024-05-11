namespace custos.API.Endpoints
{
    public static partial class InstalledSoftwareExtension
    {
        public static RouteGroupBuilder MapInstalledSoftwareInformationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/addinstalledSoftwareInformation", AddInstalledSoftwareInformation);
            group.MapGet("/getinstalledSoftwareInformation", GetInstalledSoftwareInformation);
            group.MapGet("/getinstalledSoftwareInformationById", GetInstalledSoftwareInformationById);

            return group;

        }
    }
}
