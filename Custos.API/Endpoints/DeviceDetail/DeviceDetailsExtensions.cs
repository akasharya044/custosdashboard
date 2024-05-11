using custos.Models;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints
{
	public static partial class DeviceDetailsExtensions
	{
		public static async Task<IResult> AddDeviceDetails(/*List<DeviceDetailsDto> data, IDataService dataService*/)
		{
			//var response = await dataService.deviceDetailsData.AddDeviceDetails(data);
			return Results.Ok();
		}
        public static async Task<IResult> RegisterDevice(/*DeviceDetailsDto data, IDataService dataService*/)
        {
            //var response = await dataService.deviceDetailsData.RegisterDevice(data);
            return Results.Ok();
        }
        public static async Task<IResult> DeviceDetailsList(IDataService dataService)
		{
			//var response = await dataService.deviceDetailsData.GetDeviceDetails();
			return Results.Ok();
		}
        public static async Task<IResult> AddDeviceLog(DeviceRunningLogDTO data, IDataService dataService)
        {
          //  var response = await dataService.deviceDetailsData.AddDeviceRunningLog(data);
            return Results.Ok();
        }
        public static async Task<IResult> SearchDeviceDetailsList(IDataService dataService, string value)
        {
           // var response = await dataService.deviceDetailsData.SearchDeviceDetails(value);
            return Results.Ok();
        }
        public static async Task<IResult> GetDeviceStatusPool(IDataService dataService)
        {
            var response = await dataService.deviceDetailsData.GetDeviceStatusPool();
            return Results.Ok(response);
        }
        public static async Task<IResult> TriggerFeedback(IDataService dataService, string deviceid)
        {
           // var response = await dataService.deviceDetailsData.TriggerFeedback(deviceid);
            return Results.Ok();
        }
		public static async Task<IResult> DeviceDetails(IDataService dataService)
		{
			var response = await dataService.deviceDetailsData.GetAllDeviceDetails();
			return Results.Ok(response);
		}
		public static async Task<IResult> DeviceDailyDetails(IDataService dataService)
		{
			//var response = await dataService.deviceDetailsData.GetDeviceDailyStatusDetail();
			return Results.Ok();
		}
	}
}
