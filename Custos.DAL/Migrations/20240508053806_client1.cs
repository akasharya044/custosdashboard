using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace custos.DAL.Migrations
{
    /// <inheritdoc />
    public partial class client1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdditionalInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Caption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OSArchitecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DomainRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastBootUpTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoOfDaysLastBoot = table.Column<int>(type: "int", nullable: true),
                    IsActivated = table.Column<bool>(type: "bit", nullable: true),
                    WindowKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogged = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminStatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalInformationHardDisk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSize = table.Column<long>(type: "bigint", nullable: true),
                    FreeSpace = table.Column<long>(type: "bigint", nullable: true),
                    AvailableFreeSpace = table.Column<long>(type: "bigint", nullable: true),
                    NonSystemDriveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonSystemTotalSpace = table.Column<long>(type: "bigint", nullable: true),
                    NonSystemFreeSpace = table.Column<long>(type: "bigint", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInformationHardDisk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdminUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AntivirusDetails",
                columns: table => new
                {
                    SystemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    AntivirusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntivirusDetails", x => x.SystemId);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displaylabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Backgroundservice",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MemoryUsages = table.Column<double>(type: "float", nullable: true),
                    CpuUsgaes = table.Column<double>(type: "float", nullable: true),
                    NetworkUsgaes = table.Column<double>(type: "float", nullable: true),
                    CPU_Alert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Memory_Alert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Memory_TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Network_Alert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Network_TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Backgroundservice", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BackgroundThreshold",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CPUUsage = table.Column<double>(type: "float", nullable: true),
                    MemoryUsage = table.Column<double>(type: "float", nullable: true),
                    NetworkUsage = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackgroundThreshold", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    displaylabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entitytype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NoKey = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientLicense",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLicense", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommandData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    commandid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    commandname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    commandargument = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDailyStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDailyStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BIOS = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VirtualMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvilableMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displayManufacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displaydetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displayname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<long>(type: "bigint", nullable: false),
                    DisplayLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "deviceInformation",
                columns: table => new
                {
                    BIOS = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MACAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VirtualMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableVirtualMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPhysicalMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAvailablePhysicalMemory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayManufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deviceInformation", x => x.BIOS);
                });

            migrationBuilder.CreateTable(
                name: "DeviceRunningLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShutDownTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRunningLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeviceStatusPool",
                columns: table => new
                {
                    DeviceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastHeartBeat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRunning = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceStatusPool", x => x.DeviceId);
                });

            migrationBuilder.CreateTable(
                name: "EventHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLog",
                columns: table => new
                {
                    PKExceptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExceptionSource = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExceptionMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLog", x => x.PKExceptionId);
                });

            migrationBuilder.CreateTable(
                name: "harddiskInformation",
                columns: table => new
                {
                    SystemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DriveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriveFormat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreeSpace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvailableFreeSpace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonSystemDriveName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonSystemTotalSpace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NonSystemFreeSpace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_harddiskInformation", x => x.SystemId);
                });

            migrationBuilder.CreateTable(
                name: "HardwareInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    IsArray = table.Column<bool>(type: "bit", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifires = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HardwareInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstalledSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstalledOn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstalledSoftware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineRegistration",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    systemid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mac_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ipaddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    agent_version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    install_ram = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hard_disk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineRegistration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMenuId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "operatingSystem",
                columns: table => new
                {
                    SerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OS_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS_Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OS_Architecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Build_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastBootUpTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoOfDaysLastSystemBoot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MembershipType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLogged = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastLoggedUserRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operatingSystem", x => x.SerialNumber);
                });

            migrationBuilder.CreateTable(
                name: "OSCore",
                columns: table => new
                {
                    WindowProductKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WindowActivationStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSCore", x => x.WindowProductKey);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    entity_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsVIP = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Upn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<long>(type: "bigint", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PortInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocalEndpoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocalPort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemoteEndpint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RemotePort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    Service = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PortInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryUsages = table.Column<long>(type: "bigint", nullable: true),
                    NetworkSpeeds = table.Column<double>(type: "float", nullable: true),
                    CPUUsgaess = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramDataLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgramNames = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PIDs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryUsages = table.Column<long>(type: "bigint", nullable: true),
                    NetworkSpeeds = table.Column<double>(type: "float", nullable: true),
                    CPUUsgaess = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramDataLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegisterDevice",
                columns: table => new
                {
                    systemid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UniqueKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    entity_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    SubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdateTime = table.Column<long>(type: "bigint", nullable: true),
                    DisplayLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MacAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgentVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterDevice", x => x.systemid);
                });

            migrationBuilder.CreateTable(
                name: "SearchQuestion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchQuestion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoftwareInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WindowTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemorySize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Starttime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CpuUsage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoftwareInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    displaylabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemHardware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLocal = table.Column<bool>(type: "bit", nullable: false),
                    IsArray = table.Column<bool>(type: "bit", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualifires = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemHardware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemSoftware",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledOn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSoftware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDeskGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredForActualService = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedByPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredForDevice_c = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    ContactPerson = table.Column<int>(type: "int", nullable: true),
                    TicketGenerated = table.Column<bool>(type: "bit", nullable: true),
                    TicketStatus = table.Column<int>(type: "int", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ResolvedDateTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssignedTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedBackRemark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpertAssignee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpertAssigneeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedByPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegisteredForLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Severity = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Addresses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Systemid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "windowServices",
                columns: table => new
                {
                    ServiceName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Startup = table.Column<bool>(type: "bit", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SystemId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_windowServices", x => x.ServiceName);
                });

            migrationBuilder.CreateTable(
                name: "UsersRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MenuId = table.Column<int>(type: "int", nullable: false),
                    Rights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersRights_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRights_MenuId",
                table: "UsersRights",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInformation");

            migrationBuilder.DropTable(
                name: "AdditionalInformationHardDisk");

            migrationBuilder.DropTable(
                name: "AdminUsers");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AntivirusDetails");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Backgroundservice");

            migrationBuilder.DropTable(
                name: "BackgroundThreshold");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientLicense");

            migrationBuilder.DropTable(
                name: "CommandData");

            migrationBuilder.DropTable(
                name: "DeviceDailyStatus");

            migrationBuilder.DropTable(
                name: "DeviceData");

            migrationBuilder.DropTable(
                name: "DeviceDetails");

            migrationBuilder.DropTable(
                name: "deviceInformation");

            migrationBuilder.DropTable(
                name: "DeviceRunningLog");

            migrationBuilder.DropTable(
                name: "DeviceStatusPool");

            migrationBuilder.DropTable(
                name: "EventHistory");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "ExceptionLog");

            migrationBuilder.DropTable(
                name: "harddiskInformation");

            migrationBuilder.DropTable(
                name: "HardwareInformation");

            migrationBuilder.DropTable(
                name: "InstalledSoftware");

            migrationBuilder.DropTable(
                name: "MachineRegistration");

            migrationBuilder.DropTable(
                name: "operatingSystem");

            migrationBuilder.DropTable(
                name: "OSCore");

            migrationBuilder.DropTable(
                name: "PersonDetails");

            migrationBuilder.DropTable(
                name: "PortInformation");

            migrationBuilder.DropTable(
                name: "ProgramData");

            migrationBuilder.DropTable(
                name: "ProgramDataLog");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "RegisterDevice");

            migrationBuilder.DropTable(
                name: "SearchQuestion");

            migrationBuilder.DropTable(
                name: "SoftwareInformation");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "SystemHardware");

            migrationBuilder.DropTable(
                name: "SystemSoftware");

            migrationBuilder.DropTable(
                name: "TicketRecord");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UsersRights");

            migrationBuilder.DropTable(
                name: "UserType");

            migrationBuilder.DropTable(
                name: "windowServices");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
