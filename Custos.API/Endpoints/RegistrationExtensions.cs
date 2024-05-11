namespace Custos.API.Endpoints
{
    public static partial class RegistrationExtensions
	{
		public static RouteGroupBuilder MapMachineRegistrationEndpoint(this RouteGroupBuilder group)
		{
			group.MapPost("/registration", AddMachineRegistration);
			group.MapGet("/registration", GetMachineData);
			return group;
		}
	}
}
