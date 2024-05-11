
using custos.DAL.DataService;

namespace Custos.DAL.DataService
{
    public interface IDataService
	{
		IAdminData adminData { get; }
		IMachineRegistrationData machineRegistrationData { get; }
		ICategoriesData categoriesData { get; }
		ISubCategoriesData subCategoriesData { get; }
		IPersonDetailsData personDetailsData { get; }
		IDeviceDetailsData deviceDetailsData { get; }
		IAreaData areadata { get; }
		IEventHistories eventHistory { get; }
		IUserSystemSoftwareData userSystemSoftwareData { get; }
	
		ISearchQuestionData searchQuestion { get; set; }
		IAdditionalInfo additionalInfo { get; set; }
		IDeviceDetailsInformation deviceDetailsInformation { get; set; }
		IHarddiskInformation harddiskInformation { get; set; }
		IOperatingSystem operatingSystem { get; set; }
		IOSCoreInformation osCoreInformation { get; set; }
		IInstalledSoftware installedSoftware { get; set; }
		IWindowServices windowServices { get; set; }
		IPortInformation portInformation { get; set; }
		IAntivirusInformation antivirusInformation {  get; set; }	

		IAdditionalInfo Backgroundservice { get; set; }
		IBackgroundThreshold BackgroundThreshold { get; set; }
		IProgramData programData { get; set; }
		ICommandInformation commandInformation { get; set; }
		IRegisterdevice registerdevice { get; set; }
        IRbacDataService rbacDataService { get; set; }
		ITicketData ticketdata { get; }
        IUserRegistrationData userRegistrationData { get; }

		
		


    }
}
