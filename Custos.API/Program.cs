using AutoMapper;
using custos.API.Endpoints;
using custos.DAL.AutoMappers;
using Custos.API.Endpoints;
using Custos.DAL.AutoMappers;
using Custos.DAL.DatabaseContexts;
using Custos.DAL.DataService;
using Custos.DAL.Processes;
using Custos.DAL.Unitofworks;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContextPool<Ciplv2DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Ciplv2DbConnection"), options => options.EnableRetryOnFailure())
                                                           .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking).EnableSensitiveDataLogging());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
var mapperconfig = new MapperConfiguration(x =>
{
    x.AddProfile(new AdminMapper());
  
    x.AddProfile(new MachineRegistrationMapper());
    x.AddProfile(new CategoriesMapper());
    x.AddProfile(new SubCategoriesMapper());
    x.AddProfile(new PersonDetailsMapper());
    x.AddProfile(new DeviceDetailsMapper());
    x.AddProfile(new AreaMappers());
    x.AddProfile(new EventHistoriesMapper());
    x.AddProfile(new UserSystemSoftwareMapper());
    x.AddProfile(new DeviceInformationMapper());
    x.AddProfile(new HarddiskInformationMapper());
    x.AddProfile(new OperatingSystemMapper());
    x.AddProfile(new WindowServicesMapper());
    x.AddProfile(new OSCoreMapper());
    x.AddProfile(new InstalledSoftwareMapper());
    x.AddProfile(new PortInformationMapper());
    x.AddProfile(new AntivirusDetailsMapper());
    x.AddProfile(new BackgroundServiceMapper());
    x.AddProfile(new BackgroundThresholdMapper());
    x.AddProfile(new ProgramDataMapper());
    x.AddProfile(new CommandInformationMapper());
    x.AddProfile(new RegisterdeviceMapper());   
    x.AddProfile(new RbacDataMapper());
    x.AddProfile(new TicketRecordMapper());
    x.AddProfile(new UserRegistrationMapper());



});
IMapper mapper = mapperconfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton(sp => RabbitConnector.CreateBus(builder.Configuration["RabbitMqHost"]));
builder.Services.AddSingleton<DeviceLogs>();
//builder.Services.AddHostedService<BackgroundProcesses>();
builder.Services.AddHostedService<RabbitListner>();
builder.Services.AddScoped<IUnitOfWorks, UnitOfWorks>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<ISieveProcessor, SieveProcessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//To get request data in exception handling
app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
});
app.UseHttpsRedirection();

app.MapGroup("api/machine").MapMachineRegistrationEndpoint().WithTags("Machine Registration API");
app.MapGroup("api/categories").MapCategoryEndpoint().WithTags("Categories API");
app.MapGroup("api/subcategories").MapSubCategoryEndpoint().WithTags("SubCategories API");
app.MapGroup("api/QuestionAnswer").MapQuestionAnswerEndpoint().WithTags("QuestionAnswer API");
app.MapGroup("api/persondetails").MapPersonDetailsEndpoint().WithTags("PersonDetails API");
app.MapGroup("api/devicedetails").MapDeviceDetailsEndpoint().WithTags("DeviceDetails API");
app.MapGroup("api/area").MapAreaEndpoint().WithTags("Area API");
app.MapGroup("api/admin").MapAdminEndpoint().WithTags("Admin API");
app.MapGroup("api/eventHistory").MapEventHistoryMapEndpoint().WithTags("EventHistory API");
app.MapGroup("api/systemInformation").MapSystemInfoEndpoint().WithTags("System Information API");
app.MapGroup("api/additional").MapAdditionalEndpoint().WithTags("Additional API");
app.MapGroup("api/deviceInformation").MapDeviceInformationEndpoint().WithTags("Device Information");
app.MapGroup("api/harddiskInformation").MapHarddiskInformationEndpoint().WithTags("Harddisk Information");
app.MapGroup("api/operatingSystem").MapOperatingSystemEndpoint().WithTags("Operating System");
app.MapGroup("api/windowservices").MapWindowServicesInformationEndpoint().WithTags("Window Services");
app.MapGroup("api/operatingSystem").MapOSCoreInformationEndpoint().WithTags("Operating System");
app.MapGroup("api/installedSoftware").MapInstalledSoftwareInformationEndpoint().WithTags("Installed Software");
app.MapGroup("api/portInformation").MapPortInformationEndpoint().WithTags("Port Information");
app.MapGroup("api/antivirusInformation").MapantivirusInformationEndpoint().WithTags("Antivirus Information");
//app.MapGroup("api/programDataInformation").MapprogramdataInformationEndpoint().WithTags("Program Data");
app.MapGroup("api/ticketrecords").MapTicketEndpoint().WithTags("Ticket Records");
app.MapGroup("api/userRegistration").MapRegistrationEndpoint().WithTags("User Registration");


app.MapGroup("api/backgroundThresholdInformation").MapBackgroundThresholdInformationEndpoint().WithTags("Threshold Information");

var appMapGroup = app.MapGroup("");

var apiMapGroup = appMapGroup.MapGroup("api/custos");
//.AddEndpointFilter<>();

apiMapGroup.MapUserManagementEndpoint();









app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
