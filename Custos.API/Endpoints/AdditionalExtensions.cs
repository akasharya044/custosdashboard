namespace Custos.API.Endpoints;

public static partial class AdditionalExtensions
{
	public static RouteGroupBuilder MapAdditionalEndpoint(this RouteGroupBuilder group)
	{
		group.MapPost("/additionalinfo/Upsert", UpsertOSInformation);
		group.MapPost("/additionalinfo/HardDisk", AddHardDiskInfo);
		group.MapPost("/additionalinfo/AddDeviceData", AddDeviceData);
		group.MapGet("/additionalinfo/Osinfo", GetOsInformation);
		group.MapGet("/additionalinfo/harddiskinfo", DiskInfo);
		group.MapGet("additionalinfo/Deviceinfo", GetDeviceDataInfo);
		group.MapPost("additionalinfo/BackgroundService", BackgroundService);
		group.MapGet("additionalinfo/getProgramdata", GetProgramData);
		group.MapPost("additionalinfo/addProgramdata", AddProgramData);
		group.MapGet("additionalinfo/getProgramdataById", GetProgramDataById);

        group.MapGet("additionalinfo/getProgramdatalog", GetProgramDataLog);
        group.MapPost("additionalinfo/addProgramdatalog", AddProgramDataLog);
        group.MapGet("additionalinfo/getProgramdatalogById", GetProgramDataLogById);
        group.MapGet("additionalinfo/GetBackgroundData", GetBackground);
        group.MapGet("additionalinfo/GetCommandInformation", GetCommandInfo);
        group.MapPost("additionalinfo/AddCommandInformation", AddCommandInfo);
		group.MapPost("/additionalinfo/AddRegisterDevice",AddRegisterDevice);
		group.MapGet("/additionalinfo/GetRegisterDevice", GetRegisterDevice);
        group.MapGet("/additionalinfo/GetRegisterDeviceById", GetRegisterDeviceById);
        return group;
	}
}
