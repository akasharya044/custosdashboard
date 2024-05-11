using custos.Models.AdditionalInfo;
using custos.Models.DTO;
using custos.Web.Components.Dto;
using custos.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Radzen;
using System.ComponentModel.Design;
using System.Text;


namespace custos.Web.Components.Pages
{
    public partial class Command
    {
        Variant variant = Variant.Filled;
        bool loading { get; set; } = true;
        string cmdmessage = "";
        string message = "";

        List<string> values = new List<string>();
        List<int> portvalues = new List<int>();
        private IConfiguration _config;




        List<CommandDataDto> _commanddata { get; set; } = new List<CommandDataDto>();
        List<BackgroundserviceDTO> _background { get; set; } = new List<BackgroundserviceDTO>();
        List<PortInformationDto> _port { get; set; } = new List<PortInformationDto>();
        List<String> systemid { get; set; } = new List<string>();
        List<String> portno { get; set; } = new List<string>();

        string singleValue = "";
        int PortValue = 0;
        string commandValue { get; set; }
        string commandargument = "";
        string comid = "";

        protected override async Task OnInitializedAsync()
        {
            if (sessionData.UserData == null || sessionData.UserData.UserName == null)
                NavigationManager.NavigateTo("/");

            await base.OnInitializedAsync();
            await LoadData();
            await CommandDataLoad();


        }

        private async Task LoadData()
        {
            try
            {
                var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetBackgroundData");
                if (output != null && output.Status == "Success")
                {
                    _background = JsonConvert.DeserializeObject<List<BackgroundserviceDTO>>(output.Data.ToString());
                    systemid = _background.Select(x => x.UserId).ToList();

                }
                loading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private async Task CommandDataLoad()
        {
            try
            {
                var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetCommandInformation");
                if (output != null && output.Status == "Success")
                {
                    _commanddata = JsonConvert.DeserializeObject<List<CommandDataDto>>(output.Data.ToString());
                    _commanddata = _commanddata.DistinctBy(x=>x.commandname).ToList();
                   

                }
                loading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task PortLoad(string systemId)
        {
            try
            {
                var output = await custosapiservice.GetData("/api/portInformation/getportInformationById?userid=" + systemId);
                if (output != null && output.Status == "Success")
                {
                    _port = JsonConvert.DeserializeObject<List<PortInformationDto>>(output.Data.ToString());
                    _port.DistinctBy(x=>x.RemotePort).ToList();
                   

                }
                loading = false;
                StateHasChanged();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task RabbitSendCommand(string commandid, string systemid, string processname, string broadcast, string commandvalue, int pid, List<string> Systemids)

        {
            RabbitDTO rabbit = new RabbitDTO();
            rabbit.commandid = commandid;
            rabbit.systemid = systemid;
            rabbit.processname = processname;
            rabbit.message = broadcast;
            rabbit.commandarguments = commandvalue;
            rabbit.processid = pid;
            rabbit.systemids = Systemids;

            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = "65.2.100.52",
                    UserName = "admin",
                    Password = "admin@123"
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.ExchangeDeclare(exchange: "CustOsMessageExchange", type: ExchangeType.Fanout);


                // channel.QueueDeclare(queue: "process_kill_requests", durable: false, exclusive: false, autoDelete: false, arguments: null);


                string serialize = JsonConvert.SerializeObject(rabbit);


                var body = Encoding.UTF8.GetBytes(serialize);

                if (body != null)
                {
                    channel.BasicPublish(exchange: "CustOsMessageExchange", routingKey: "", basicProperties: null, body: body);
                    if (commandid != "101")
                    {

                        var msg = new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Message Sent", Detail = "Request Sent", Duration = 4000 };
                        notificationservice.Notify(msg);
                    }


                }
                else
                {
                    // Handle the case when the body is null
                    var errorMsg = "Message body is null.";
                    Console.WriteLine(errorMsg);
                    var errorNotification = new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error Sending Message", Detail = errorMsg, Duration = 4000 };
                    notificationservice.Notify(errorNotification);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                var errorMessage = $"Error sending message: {ex.Message}";
                Console.WriteLine(errorMessage);
                var errorNotification = new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error Sending Message", Detail = errorMessage, Duration = 4000 };
                notificationservice.Notify(errorNotification);
            }
        }

        private async Task GetCmdData(string value)
        {
            try
            {
                commandargument = _commanddata.Find(x => x.commandname == value).commandargument;
                comid = _commanddata.Find(x => x.commandname == value).commandid;
            }
            catch (Exception ex)
            {

            }
        }

        

    }
}
