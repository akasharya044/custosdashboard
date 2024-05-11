namespace custos.API.Endpoints
{
    public static partial class UserManagementExtension
    {

        public static RouteGroupBuilder MapUserManagementEndpoint(this RouteGroupBuilder group)
        {
            var routegroup = group.MapGroup("users").WithTags("User Management API");
            routegroup.MapPost("/signIn", SignIn);
            routegroup.MapPost("/client", CreateClient);
            routegroup.MapGet("", GetAllClient);
            routegroup.MapGet("menu/{UserTypeId}/{UserId}", GetAllMenuRights);
            routegroup.MapGet("menu/{menuId}", GetMenuById);
			routegroup.MapGet("/GetAllState", GetAllState);
			routegroup.MapGet("/{clientId}", GetClientLicence);
            routegroup.MapPost("/AgentRegistration", AgentRegistration);
			return group;

        }

    }

}
