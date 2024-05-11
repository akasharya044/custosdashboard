using custos.Models;
using custos.Models.AdditionalInfo;
using custos.Models.DTO;
using custos.Models.SystemInfo;
using Custos.DAL.DataService;

namespace Custos.API.Endpoints;

public static partial class AdditionalExtensions
{
	public static async Task<IResult> UpsertOSInformation(AdditionalInformationDTO data, IDataService dataService)
	{
		var response = await dataService.additionalInfo.AddOSInfromation(data);
		return Results.Ok(response);
	}

	public static async Task<IResult> GetOsInformation(IDataService dataService)
	{
		var response = await dataService.additionalInfo.GetOsInformation();
		return Results.Ok(response);

    }


    public static async Task<IResult> AddHardDiskInfo(AdditionalInformationHardDiskDto data , IDataService dataService)
	{
		var response = await dataService.additionalInfo.AddHardDiskInfo(data);
		return Results.Ok(response);
	}

	public static async Task<IResult> DiskInfo (IDataService dataservice)
	{
		var response = await dataservice.additionalInfo.Diskinfo();
		return Results.Ok(response);

    }

	

	public static async Task<IResult> AddDeviceData (DeviceDataDto data , IDataService dataService)
	{
		var response = await dataService.additionalInfo.AddDeviceData(data);
		return Results.Ok(response);
	}

	public static async Task<IResult> GetDeviceDataInfo (IDataService dataService)
	{
		var response = await dataService.additionalInfo.GetDeviceDataInfo();
		return Results.Ok(response);
	}
    public static async Task<IResult> AddRegisterDevice(RegisterDeviceDto data, IDataService dataService)
    {
        var response = await dataService.registerdevice.AddRegisterdeviceInformation(data);
        return Results.Ok(response);
    }

    public static async Task<IResult> BackgroundService (IDataService dataService , BackgroundserviceDTO data)
	{
		var response = await dataService.Backgroundservice.Backgroundservice(data);
		return Results.Ok(response);
	}
    public static async Task<IResult> AddProgramDataLog(IDataService dataService, List<ProgramDataLogDto> data)
    {
        var response = await dataService.programData.AddProgramDataLogInformation(data);
        return Results.Ok(response);
    }
    public static async Task<IResult> AddProgramData(IDataService dataService,List<ProgramDataDto> data)
    {
        var response = await dataService.programData.AddProgramDataInformation(data);
        return Results.Ok(response);
    }
    public static async Task<IResult> GetRegisterDevice(IDataService dataService)
    {
        var response = await dataService.registerdevice.GetRegisterdeviceInformation();
        return Results.Ok(response);
    }
    public static async Task<IResult> GetRegisterDeviceById(IDataService dataService,string userid)
    {
        var response = await dataService.registerdevice.GetRegisterdeviceInformationById(userid);
        return Results.Ok(response);
    }
    public static async Task<IResult> GetProgramData(IDataService dataService)
    {
        var response = await dataService.programData.GetProgramDataInformation();
        return Results.Ok(response);
    }
    public static async Task<IResult> GetProgramDataLog(IDataService dataService)
    {
        var response = await dataService.programData.GetProgramDataLogInformation();
        return Results.Ok(response);
    }
    public static async Task<IResult> GetProgramDataById(IDataService dataService,string userid)
    {
        var response = await dataService.programData.GetProgramDataInformationByUserId(userid);
        return Results.Ok(response);
    }
    public static async Task<IResult> GetProgramDataLogById(IDataService dataService, string userid)
    {
        var response = await dataService.programData.GetProgramDataLogInformationByUserId(userid);
        return Results.Ok(response);
    }

    public static async Task<IResult> GetBackground (IDataService dataService)
	{
		var response = await dataService.Backgroundservice.GetBackground();
		return Results.Ok(response);

    }
    public static async Task<IResult> GetCommandInfo(IDataService dataService)
    {
        var response = await dataService.commandInformation.GetCommandInformation();
        return Results.Ok(response);

    }
    public static async Task<IResult> AddCommandInfo(IDataService dataService, List<CommandDataDto> data)
    {
        var response = await dataService.commandInformation.AddCommandInformation(data);
        return Results.Ok(response);
    }



    //public static async Task<IResult> AddCommand (IDataService dataService)
    //{
    //	var response = await dataService.
    //}

}
