using custos.Models;
using custos.Models.DTO;
using custos.Models.Master;
using custos.Models.RbacModel;
using custos.Models.SystemInfo;
using custos.Models;


//using custos.Models.DTO;
using custos.Modelss;
using Microsoft.EntityFrameworkCore;
using custos.Models.AdditionalInfo;
using custos.Models.UserRegistration;

namespace Custos.DAL.Unitofworks
{
    public interface IUnitOfWorks 
    {
       // IRepository<Test> test {  get; } 
        IRepository<MachineRegistration> machineRegistration { get; }
		IRepository<Categories> categories { get; }
		IRepository<SubCategories> subCategories { get; }
		IRepository<Questions> questions { get; }

        IRepository<TicketRecord> ticketrecord { get; }

        IRepository<Answers> answers { get; }
		IRepository<PersonDetails> personDetails { get; }
		IRepository<custos.Models.DeviceDetails> deviceDetails { get; }
		IRepository<Areas> area { get; }
        IRepository<DeviceRunningLog> deviceRunningLog { get; }
		IRepository<AdminUsers> adminUsers { get; }
		IRepository<EventHistory> eventHistory { get; }
		IRepository<Events> events { get; }
		IRepository<SoftwareInformation> UserSystemSoftware { get; set; }
		IRepository<HardwareInformation> UserSystemHardware { get; set; }
		IRepository<SearchQuestion> searchQuestion { get; set; }
		IRepository<DeviceDailyStatus> deviceDailyStatus { get; set; }
		IRepository<AdditionalInformation> additionalInformation { get; set; }

		IRepository<AdditionalInformationHardDisk> harddiskinfo { get; set; }
		IRepository<custos.Models.DTO.DeviceDetails> devicedetails { get; set; }
		IRepository<custos.Models.DTO.HarddiskDetails> harddiskdetails { get; set; }
		IRepository<custos.Models.DTO.OperatingSystem1> operatingsystem { get; set; }
		IRepository<WindowServices> windowservices { get; set; }
		IRepository<OSCore> OSCore { get; set; }
		IRepository<InstalledSoftware> installedsoftware { get; set; }


		IRepository<DeviceData> deviceData { get; set; }
		IRepository<PortInformation> portinformation { get; set; }
		IRepository<AntivirusDetails> antivirusDetails { get; set; }

		IRepository<Backgroundservice>background { get; set; }
		IRepository<BackgroundThreshold> backgroundthreshold { get; set; }
		IRepository<ProgramData> programdata { get; set; }
		IRepository<Client> client { get; set; }
		IRepository<ClientLicense> clientLicense { get; set; }
		IRepository<Users> users { get; set; }
		IRepository<UsersRights> usersRights { get; set; }
		IRepository<UserType> userType { get; set; }
		IRepository<Menu> menu { get; set; }
		IRepository<State> state { get; set; }
		IRepository<CommandData> commanddata { get; set; }
		IRepository<RegisterDevice> registerdevice { get; set; }
		IRepository<ProgramDataLog> programdatalog { get; set; }
        IRepository<UserRegistrations> userRegistraion { get; }
		IRepository<Key> keyRegistration { get; set; }	

        Task SaveAsync();
        void Save();
        void ClearTracker();
        Task BeginTrans();
        Task Commit();
		Task RollBackTrans();

        Task<string> AddException(Exception exception);
    }
}
