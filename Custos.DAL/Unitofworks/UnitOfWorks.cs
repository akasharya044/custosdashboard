using custos.Models;
using custos.Models.DTO;
using custos.Models.Master;
using custos.Models.RbacModel;
using custos.Models.SystemInfo;
using custos.Models;
using custos.Modelss;
using Custos.DAL.DatabaseContexts;
using Custos.DAL.Processes;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting;
using custos.Models.AdditionalInfo;
using custos.Models.UserRegistration;

namespace Custos.DAL.Unitofworks
{
    public class UnitOfWorks : IDisposable, IUnitOfWorks
    {
        readonly Ciplv2DbContext _context;
        private IDbContextTransaction transaction = null;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private bool disposed = false;
 
        public UnitOfWorks(Ciplv2DbContext dbcontext, IHostEnvironment hostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _context = dbcontext;
            _hostEnvironment = hostEnvironment;
            _httpContextAccessor = httpContextAccessor;
           // test = new Repository<Test>(_context);
			machineRegistration = new Repository<MachineRegistration>(_context);
			categories = new Repository<Categories>(_context);
            ticketrecord = new Repository<TicketRecord>(_context);

            subCategories = new Repository<SubCategories>(_context);
			questions = new Repository<Questions>(_context);
			answers = new Repository<Answers>(_context);
			personDetails = new Repository<PersonDetails>(_context);
			deviceDetails = new Repository<custos.Models.DeviceDetails>(_context);
			area = new Repository<Areas>(_context);
            deviceRunningLog = new Repository<DeviceRunningLog>(_context);
			adminUsers = new Repository<AdminUsers>(_context);
			eventHistory = new Repository<EventHistory>(_context);
			events = new Repository<Events>(_context);
			UserSystemSoftware = new Repository<SoftwareInformation>(_context);
			UserSystemHardware = new Repository<HardwareInformation>(_context);
			searchQuestion = new Repository<SearchQuestion>(_context);
			deviceDailyStatus = new Repository<DeviceDailyStatus>(_context);
			additionalInformation = new Repository<AdditionalInformation>(_context);
			harddiskinfo = new Repository<AdditionalInformationHardDisk>(_context);
			deviceData = new Repository<DeviceData>(_context);
            devicedetails=new Repository<custos.Models.DTO.DeviceDetails>(_context);
            harddiskdetails=new Repository<custos.Models.DTO.HarddiskDetails>(_context);
            operatingsystem=new Repository<custos.Models.DTO.OperatingSystem1>(_context);  
            windowservices=new Repository<WindowServices>(_context);
            OSCore=new Repository<OSCore>(_context);
            installedsoftware = new Repository<InstalledSoftware>(_context);
            portinformation=new Repository<PortInformation>(_context);
            antivirusDetails=new Repository<AntivirusDetails>(_context);
            background = new Repository<Backgroundservice>(_context);
            backgroundthreshold=new Repository<BackgroundThreshold>(_context);
            programdata = new Repository<ProgramData>(_context);
            client = new Repository<Client>(_context);
            clientLicense = new Repository<ClientLicense>(_context);
            users = new Repository<Users>(_context);
            userType = new Repository<UserType>(_context);
            usersRights = new Repository<UsersRights>(_context);
            menu = new Repository<Menu>(_context);
			state = new Repository<State>(_context);
            commanddata=new Repository<CommandData>(_context);
            registerdevice=new Repository<RegisterDevice>(_context);
            programdatalog=new Repository<ProgramDataLog>(_context);
            userRegistraion = new Repository<UserRegistrations>(_context);
            keyRegistration=new Repository<Key>(_context);



        }
    // public IRepository<Test> test { get; private set; }
    public IRepository<AdminUsers> adminUsers { get; private set; }
        public IRepository<MachineRegistration> machineRegistration { get; private set; }
		public IRepository<Categories> categories { get; private set; }
		public IRepository<SubCategories> subCategories { get; private set; }

        public IRepository<TicketRecord> ticketrecord { get; private set; }

        public IRepository<Questions> questions { get; private set; }
		public IRepository<Answers> answers { get; private set; }
		public IRepository<PersonDetails> personDetails { get; private set; }
		public IRepository<custos.Models.DeviceDetails> deviceDetails { get; private set; }
		public IRepository<Areas> area { get; private set; }
        public IRepository<DeviceRunningLog> deviceRunningLog { get; private set; }
		public IRepository<EventHistory> eventHistory { get; private set; }
		public IRepository<Events> events { get; private set; }
		public IRepository<SoftwareInformation> UserSystemSoftware { get; set; }
		public IRepository<HardwareInformation> UserSystemHardware { get; set; }
		public IRepository<SearchQuestion> searchQuestion { get; set; }
		public IRepository<DeviceDailyStatus> deviceDailyStatus { get; set; }
		public IRepository<AdditionalInformation> additionalInformation { get; set; }
        public IRepository<PortInformation> portinformation { get; set; }

		public IRepository<AdditionalInformationHardDisk> harddiskinfo { get; set; }
        public IRepository<custos.Models.DTO.DeviceDetails> devicedetails { get; set; }
        public IRepository<custos.Models.DTO.HarddiskDetails> harddiskdetails { get; set; }
        public IRepository<custos.Models.DTO.OperatingSystem1> operatingsystem { get; set; }
        public IRepository<WindowServices> windowservices { get; set; }
        public IRepository<OSCore> OSCore { get; set; }
        public IRepository<InstalledSoftware> installedsoftware { get; set; }
        public IRepository<AntivirusDetails> antivirusDetails { get; set; }
        
        public IRepository<Backgroundservice> background { get; set; }

		public IRepository<DeviceData> deviceData { get; set; }
        public IRepository<ProgramData> programdata { get; set; }
        public IRepository<BackgroundThreshold> backgroundthreshold { get; set; }
        public IRepository<Client> client { get; set; }
        public IRepository<ClientLicense> clientLicense { get; set; }
        public IRepository<Users> users { get; set; }
        public IRepository<UserType> userType { get; set; }
        public IRepository<UsersRights> usersRights { get; set; }
        public IRepository<Menu> menu { get; set; }
        public IRepository<State> state { get; set; }
        public IRepository<CommandData> commanddata { get; set; }
        public IRepository<RegisterDevice> registerdevice { get; set; }
        public IRepository<ProgramDataLog> programdatalog { get; set; }
        public IRepository<UserRegistrations> userRegistraion { get; private set; }
        public IRepository<Key> keyRegistration { get; set; }
        public async Task<string> AddException(Exception exception)
        {
            string output = _hostEnvironment.EnvironmentName == "Production" ? "Technical Error - Contact Admin" : exception.Message.ToString();
            try
            {
                var endpoint = _httpContextAccessor.HttpContext.Request.Path;
                var method = _httpContextAccessor.HttpContext.Request.Method;
                string body = "";
                body += GetBodyString();

                if (_httpContextAccessor.HttpContext.Request.QueryString != null)
                {
                    body += _httpContextAccessor.HttpContext.Request.QueryString.ToString();
                }

                //Add table to add exception
                ExceptionLog exceptionLog = new ExceptionLog();
                exceptionLog.Logdate = DateTime.Now;
                exceptionLog.ExceptionMessage = exception.Message;
                exceptionLog.ExceptionSource = exception.Source;
                exceptionLog.ExceptionURL = endpoint;
                exceptionLog.RequestData = body;
                exceptionLog.ActionMethod = method;

                //Create exception object and save it to DB
                await _context.ExceptionLogs.AddAsync(exceptionLog);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                LogWriter.LogWrite(exception.Message);

            }
            return output;
        }
        private string GetBodyString()
        {
            try
            {
                string body = "";


                _httpContextAccessor.HttpContext.Request.Body.Seek(0, SeekOrigin.Begin);
                using (StreamReader stream = new StreamReader(_httpContextAccessor.HttpContext.Request.Body))
                {

                    body = stream.ReadToEnd();

                    // body = "param=somevalue&param2=someothervalue"
                }
                return body;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public async Task BeginTrans()
        {
            transaction = _context.Database.BeginTransaction();
        }
        public async Task Commit()
        {
            transaction.Commit();
        }
        public async Task RollBackTrans()
        {
            transaction.Rollback();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void ClearTracker()
        {
            _context.ChangeTracker.Clear();
        }
    }
}
