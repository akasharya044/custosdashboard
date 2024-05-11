using custos.Models;
using custos.DAL.DatabaseContexts.AdditionalInfo;
using custos.DAL.DatabaseContexts.Admin;
using custos.DAL.DatabaseContexts.EventHistories;
using custos.DAL.DatabaseContexts.Master;
using custos.DAL.DatabaseContexts.Tickets;
using custos.Models.DTO;
using custos.Models.Master;
using custos.Modelss;
using Microsoft.EntityFrameworkCore;
using custos.Models.AdditionalInfo;
using custos.Models.SystemInfo;
using custos.Models.UserRegistration;
using custos.DAL.DatabaseContexts.UserRegistration;

namespace Custos.DAL.DatabaseContexts
{
	public class Ciplv2DbContext : DbContext
	{
		public Ciplv2DbContext(DbContextOptions<Ciplv2DbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.AddAdditionallnformation();
			modelBuilder.AddTicket();
            modelBuilder.AddAdditionallnformationHardDisk();
			modelBuilder.AddDeviceData();
			modelBuilder.AddMachineRegistration();
			modelBuilder.AddSystemHardware();
			modelBuilder.AddSystemSoftware();
            modelBuilder.AddAdminUsers();
            modelBuilder.AddDeviceStatusPool();
            modelBuilder.AddExceptionLog();
            modelBuilder.AddEventHistory();
            modelBuilder.AddEvent();
            modelBuilder.AddAnswer();
            modelBuilder.AddAreas();
            modelBuilder.AddCategories();
            modelBuilder.AddDeviceStatus();
            modelBuilder.AddDeviceDetail();
            modelBuilder.AddDeviceRunningLog();
            modelBuilder.AddPersonDetail();
            modelBuilder.AddQuestion();
            modelBuilder.AddSearchQuestion();
            modelBuilder.AddSubCategories();
			modelBuilder.AddClient();
			modelBuilder.AddClientLicense();
			modelBuilder.AddUsers();
			modelBuilder.AddUserType();
			modelBuilder.AddUserRights();
			modelBuilder.AddMenus();
			modelBuilder.AddState();
			modelBuilder.BackgroundData();
            //modelBuilder.AddRegistration();

        }

		public DbSet<TicketRecord> TicketRecords { get; set; }	
		public DbSet<ExceptionLog> ExceptionLogs { get; set; }
		public DbSet<MachineRegistration> MachineRegistration { get; set; }
		public DbSet<Categories> Categories { get; set; }
		public DbSet<SubCategories> SubCategories { get; set; }
		public DbSet<Questions> Questions { get; set; }
		public DbSet<SearchQuestion> searchQuestions { get; set; }
		public DbSet<Answers> Answers { get; set; }
		public DbSet<PersonDetails> PersonDetails { get; set; }
		//public DbSet<DeviceDetails> DeviceDetails { get; set; }
		public DbSet<Areas> Areas { get; set; }
		public DbSet<DeviceRunningLog> DeviceRunningLog { get; set; }
		public DbSet<AdminUsers> AdminUsers { get; set; }
		public DbSet<custos.Models.DTO.DeviceDetails> deviceInformation { get; set; }

		public DbSet<DeviceDailyStatus> deviceDailyStatuses { get; set; }
		public DbSet<OSCore> OSCore { get; set; }

		public DbSet<DeviceStatusPool> DeviceStatusPool { get; set; }	
		public DbSet<EventHistory> EventHistory { get; set; }
		public DbSet<Events> Events { get; set; }
		//public DbSet<SystemSoftware> UserSystemSoftware { get; set; }
		//public DbSet<SystemHardware> userSystemHardwares { get; set; }
		public DbSet<SearchQuestion> SearchQuestions { get; set; }
		public DbSet<DeviceDailyStatus> DeviceDailyStatus { get; set; }
		public DbSet<AdditionalInformation> AdditionalInformation { get; set; }
		public DbSet<AdditionalInformationHardDisk> HardDisks { get; set; }
		public DbSet<DeviceData> DeviceData { get; set; }
		public DbSet<HarddiskDetails> harddiskInformation { get; set; }	
		public DbSet<custos.Models.DTO.OperatingSystem1> operatingSystem { get; set; }
		public DbSet<WindowServices> windowServices { get; set; }
		public DbSet<InstalledSoftware> InstalledSoftware { get; set; }
		public DbSet<SoftwareInformation> SoftwareInformation { get; set; }
		public DbSet<HardwareInformation> HardwareInformation { get; set; }
		public DbSet <BackgroundThreshold> BackgroundThreshold { get; set; }
		public DbSet<PortInformation> PortInformation { get; set; }
		public DbSet<AntivirusDetails> AntivirusDetails { get; set; }
		public DbSet<ProgramData> ProgramData { get; set; }
		public DbSet<State> State { get; set; }

		public DbSet<CommandData> CommandData { get; set; }
		public DbSet<RegisterDevice> RegisterDevice { get; set; }
		public DbSet<ProgramDataLog> ProgramDataLog { get; set; }
        //public DbSet<UserRegistrations> UserRegistrations { get; set; }
		//public DbSet<Key> keyregister { get; set; }



    }
}
