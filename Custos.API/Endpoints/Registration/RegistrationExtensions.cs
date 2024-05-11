using custos.Models;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class RegistrationExtensions
	{
		public static async Task<IResult> AddMachineRegistration(MachineRegistrationDto data, IDataService dataService)
		{
			var response = await dataService.machineRegistrationData.AddMachineRegistration(data);
			return Results.Ok(response);
		}
        public static async Task<IResult> GetMachineData(IDataService dataService)
        {
            var response = await dataService.machineRegistrationData.GetMachinesData();
            return Results.Ok(response);
        }
    }
}
