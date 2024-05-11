using custos.Modelss;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class PersonDetailsExtensions
	{
		public static async Task<IResult> AddPersonDetails(/*//List<PersonDetailsDto> data, IDataService dataService*/)
		{
			//var response = await dataService.personDetailsData.AddPersonDetails(data);
			return Results.Ok();
		}
		public static async Task<IResult> PersonDetailsList(IDataService dataService)
		{
			var response = await dataService.personDetailsData.GetPersonDetails();
			return Results.Ok(response);
		}
        public static async Task<IResult> SearchPersonDetailsList(IDataService dataService, string value)
        {
            //var response = await dataService.personDetailsData.SearchPersonDetails(value);
            return Results.Ok();
        }
    }
}
