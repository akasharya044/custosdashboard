namespace custos.API.Endpoints
{
    public static partial class UserRegistrationExtension
    {
        public static RouteGroupBuilder MapRegistrationEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("", AddRegistration);
            group.MapGet("", GetRegistration);
            group.MapPost("/key", AddKey);
            group.MapGet("/getkey", GetKey);
            return group;
        }
    }
}
