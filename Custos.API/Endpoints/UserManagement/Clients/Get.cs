using Custos.DAL.DataService;
using custos.Models.RbacModel;

namespace custos.API.Endpoints
{
    public static partial class UserManagementExtension
    {
        public static async Task<IResult> GetAllClient(IDataService dataService)
        {
            var response = await dataService.rbacDataService.GetAllClient();
            return Results.Ok(response);
        }

        public static async Task<IResult> GetAllMenuRights(int UserTypeId,int UserId, IDataService dataService)
        {
            var response = await dataService.rbacDataService.GetMenuList(UserTypeId,UserId);
            return Results.Ok(response);
        }


        public static async Task<IResult> GetMenuById(int menuId, IDataService dataService)
        {
            var response = await dataService.rbacDataService.GetMenuById(menuId);
            return Results.Ok(response);
		}
		public static async Task<IResult> GetAllState(IDataService dataService)
		{
			var response = await dataService.rbacDataService.GetAllState();
			return Results.Ok(response);
		}
		public static async Task<IResult> GetClientLicence(IDataService dataService, int clientId)
		{
			var response = await dataService.rbacDataService.GetClientLicence(clientId);
			return Results.Ok(response);
		}

        

	}
}
