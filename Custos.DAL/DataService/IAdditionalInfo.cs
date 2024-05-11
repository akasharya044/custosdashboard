using custos.Models;
using custos.Models.DTO;

namespace Custos.DAL.DataService;

public interface IAdditionalInfo
{
	Task<Response> AddOSInfromation(AdditionalInformationDTO data);

	Task<Response> GetOsInformation();

    Task<Response> AddHardDiskInfo(AdditionalInformationHardDiskDto data);

	Task<Response> Diskinfo();


	Task<Response> AddDeviceData (DeviceDataDto data);

	Task<Response> GetDeviceDataInfo();

	Task<Response> Backgroundservice(BackgroundserviceDTO data);

	Task<Response> GetBackground();

}
