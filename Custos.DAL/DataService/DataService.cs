using AutoMapper;
using custos.DAL.DataService;
using custos.Models.Master;
using custos.Models.UserRegistration;
using Custos.DAL.Processes;
using Custos.DAL.Unitofworks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Sieve.Services;

namespace Custos.DAL.DataService
{
    public class DataService : IDataService
    { 
        public DataService(IUnitOfWorks UOW, IMapper mapper, IHostEnvironment hostEnvironment, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory,DeviceLogs deviceLogs, ISieveProcessor sieveProcessor)
        {
            adminData = new AdminData(UOW, mapper);
            machineRegistrationData=new MachineRegistrationData(UOW,mapper);
			ticketdata = new TicketData(UOW,mapper);
            categoriesData = new CategoriesData(UOW,mapper);
            subCategoriesData = new SubCategoriesData(UOW,mapper);
            personDetailsData = new PersonDetailsData(UOW,mapper);
            deviceDetailsData = new DeviceDetailsData(UOW,mapper,deviceLogs);
			areadata = new AreaData(UOW, mapper);
			eventHistory = new EventHistories(UOW, mapper);
			userSystemSoftwareData = new UserSystemSoftwareData(mapper, UOW);
			searchQuestion = new SearchQuestionData(UOW, mapper);
			additionalInfo = new AdditionalInfo(UOW, mapper);
			deviceDetailsInformation=new DeviceDetailsInformation(UOW,mapper);
			harddiskInformation=new HarddiskInformation(UOW,mapper);
			operatingSystem = new OperatingSystemInformation(UOW, mapper);
			osCoreInformation=new OSCoreInformation(UOW,mapper);
			installedSoftware = new InstalledSoftwareInformation(mapper,UOW);
			windowServices=new WindowServicesDetail(UOW,mapper);
			portInformation=new PortDetails(mapper,UOW);
			antivirusInformation = new AntivirusInformation(UOW, mapper);
			Backgroundservice = new AdditionalInfo(UOW, mapper);
			BackgroundThreshold=new BackgroundThresholdInformation(UOW, mapper);
			programData=new ProgramDataInformation(mapper,UOW);
			commandInformation=new CommandInformation(UOW,mapper);
			registerdevice=new RegisterDeviceInformation(UOW,mapper);
            rbacDataService = new RbacDataService(UOW, mapper, configuration);
            userRegistrationData = new UserRegistrationData(UOW, mapper);

        }

		public ITicketData ticketdata { get; private set; }
        public IAdminData adminData {get; private set;}
        public IMachineRegistrationData machineRegistrationData { get; private set;}
		public ICategoriesData categoriesData { get; private set; }
		public ISubCategoriesData subCategoriesData { get; private set; }
		public IPersonDetailsData personDetailsData { get; private set; }
		public IDeviceDetailsData deviceDetailsData { get; private set; }
		public IAreaData areadata { get; private set; }
		public IEventHistories eventHistory { get; set; }
		public IUserSystemSoftwareData userSystemSoftwareData { get; private set; }
        
		public ISearchQuestionData searchQuestion { get; set; }
		public IOperatingSystem operatingSystem { get; set; }

		public IAdditionalInfo additionalInfo { get; set; }
		public IDeviceDetailsInformation deviceDetailsInformation { get; set; }
		public IHarddiskInformation harddiskInformation { get; set; }
		public IOSCoreInformation osCoreInformation { get; set; }
		public IInstalledSoftware installedSoftware { get; set; }
		public IWindowServices windowServices { get; set; }	
		public IPortInformation portInformation { get; set; }
		public IAntivirusInformation antivirusInformation { get; set;}

		public IAdditionalInfo Backgroundservice { get; set; }
		public IBackgroundThreshold BackgroundThreshold { get; set; }
		public IProgramData programData { get; set; }
		public IRbacDataService rbacDataService { get; set; }
       
       public ICommandInformation commandInformation { get; set; }
		public IRegisterdevice registerdevice { get; set; }
        public IUserRegistrationData userRegistrationData { get; private set; }

    }
}
