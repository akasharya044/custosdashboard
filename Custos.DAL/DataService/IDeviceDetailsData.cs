using custos.Models;

namespace Custos.DAL.DataService
{
	public interface IDeviceDetailsData
	{
		////Task<Response> AddDeviceDetails(List<DeviceDetailsDto> data);
		//      //Task<Response> RegisterDevice(DeviceDetailsDto data);
		//      Task<Response> GetDeviceDetails();
		//Task<Response> AddDeviceRunningLog(DeviceRunningLogDTO data);
		//      Task<Response> SearchDeviceDetails(string value);
		      Task<Response> GetDeviceStatusPool();
		//      Task<Response> TriggerFeedback(string machineid);
		//Task<Response> GetDeviceDetail();
		//Task<Response> GetDeviceDailyStatusDetail();
		Task<Response> GetAllDeviceDetails();

	}
}
