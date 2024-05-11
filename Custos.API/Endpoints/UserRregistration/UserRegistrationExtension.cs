using Custos.DAL.DataService;
using custos.Models.Tickets;
using Microsoft.AspNetCore.Mvc;
using custos.Models.UserRegistration;

namespace custos.API.Endpoints

{
    public static partial class UserRegistrationExtension
    {
        public static async Task<IResult> GetRegistration([FromServices] IDataService dataService, string systemid)
        {
            var response = await dataService.userRegistrationData.GetRegistration(systemid);
            return Results.Ok(response);
        }
        public static async Task<IResult> AddRegistration([FromBody] UserRegistrationDto userDto, IDataService dataService)
        {
            var response = await dataService.userRegistrationData.AddRegistraton(userDto);
            return Results.Ok(response);
        }

        public static async Task<IResult>AddKey(IDataService dataService , KeyDTO key) 
        {
            var response = await dataService.userRegistrationData.AddKey(key);
            return Results.Ok(response);
        }

        public static async Task<IResult>GetKey(IDataService dataService,string key)
        {
            var response = await dataService.userRegistrationData.GetKey(key);
            return Results.Ok(response);
        }
    }
}
