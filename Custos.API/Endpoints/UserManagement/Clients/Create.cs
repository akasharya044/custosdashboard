using Custos.DAL.DataService;
using custos.Models.DTO;
using custos.Models.RbacModel;

namespace custos.API.Endpoints
{

    public static partial class UserManagementExtension
    {
        public static async Task<IResult> SignIn(LoginDTO data, IDataService dataService)
        {
            var response = await dataService.rbacDataService.ValidateSignIn(data);
            return Results.Ok(response);
        }

        public static async Task<IResult> CreateClient(ClientDTO data, IDataService dataService)
        {
            var response = await dataService.rbacDataService.CreateClient(data);
            return Results.Ok(response);
        }

        public static async Task<IResult> AgentRegistration(AgentRegistrationDTO data , IDataService dataService)
        {
            var response = await dataService.rbacDataService.AgentRegistration(data);
            return Results.Ok(response);
        }

        
    }
}
