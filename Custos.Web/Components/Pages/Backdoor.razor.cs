using custos.Models.DTO;
using custos.Web.Components.Dto;
using custos.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Radzen;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using System.Text;

namespace custos.Web.Components.Pages
{
    public partial class Backdoor
    {

        Variant variant = Variant.Filled;
        bool loading { get; set; } = true;
        string cmdmessage = "";
        string message = "";
       

       
    
        List<string> values=new List<string>();
        List<int> portvalues =new List<int>();
        





        List<BackgroundserviceDTO> _background { get; set; } = new List<BackgroundserviceDTO>();
        List<PortInformationDto> _port { get; set; } = new List<PortInformationDto>();
        List<String> systemid { get; set; } = new List<string>();
        List<String> portno { get; set; } = new List<string>();

        string singleValue = "";

        protected override async Task OnInitializedAsync()
        {
            if (sessionData.UserData == null || sessionData.UserData.UserName == null)
                NavigationManager.NavigateTo("/");

            await base.OnInitializedAsync();
            await LoadData();
            
            
        }

        



        private async Task LoadData()
        {
            try
            {
                var output = await custosapiservice.GetData("/api/additional/additionalinfo/GetBackgroundData");
                if (output != null && output.Status == "Success")
                {
                    _background = JsonConvert.DeserializeObject<List<BackgroundserviceDTO>>(output.Data.ToString());
                    systemid = _background.Select(x =>x.UserId).ToList();

                }
                loading = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        
        





        private async Task RabbitSendMessage(string commandid, string systemid, string processname, string broadcast, string commandvalue, int pid, List<string> Systemids)
        {
            try
            {
                RabbitDTO rabbit = new RabbitDTO();
                rabbit.commandid = "102";
                rabbit.systemid = systemid;
                rabbit.processname = processname;
                rabbit.message = broadcast;
                rabbit.commandarguments = commandvalue;
                rabbit.processid = pid;
                rabbit.systemids = Systemids;



                var factory = new ConnectionFactory
                {
                    HostName = "65.2.100.52",
                    UserName = "admin",
                    Password = "admin@123"
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.ExchangeDeclare(exchange: "CustOsMessageExchange", type: ExchangeType.Fanout);


               

                string serialize = JsonConvert.SerializeObject(rabbit);


                var body = Encoding.UTF8.GetBytes(serialize);



                if (body != null)
                {
                    
                    channel.BasicPublish(exchange: "CustOsMessageExchange", routingKey: "", basicProperties: null, body: body);



                    var msg = new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Message Sent", Detail = "Request Sent", Duration = 4000 };
                    notificationservice.Notify(msg);
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


        private async Task RabbitSendCommandMessage(string commandmessage, List<string> systemIds)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "65.2.100.52",
                    UserName = "admin",
                    Password = "admin@123"
                };

                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "announcementRequest1", durable: false, exclusive: false, autoDelete: false, arguments: null);


                var systemIdsString = string.Join(",", systemIds);

                var message = $"{commandmessage},{systemIdsString}";
                var body = Encoding.UTF8.GetBytes(message);

                if (body != null)
                {
                    channel.BasicPublish(exchange: "", routingKey: "announcementRequest1", basicProperties: null, body: body);

                    var msg = new NotificationMessage { Severity = NotificationSeverity.Success, Summary = "Command Execute", Detail = "Command Execute", Duration = 4000 };
                    notificationservice.Notify(msg);
                }
                else
                {
                    // Handle the case when the body is null
                    var errorMsg = "Message body is null.";
                    Console.WriteLine(errorMsg);
                    var errorNotification = new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error Executing Message", Detail = errorMsg, Duration = 4000 };
                    notificationservice.Notify(errorNotification);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                var errorMessage = $"Error Executing command: {ex.Message}";
                Console.WriteLine(errorMessage);
                var errorNotification = new NotificationMessage { Severity = NotificationSeverity.Error, Summary = "Error Executing command", Detail = errorMessage, Duration = 4000 };
                notificationservice.Notify(errorNotification);
            }
        }



        private async void SendMessage(List<string> sysid)
        {
            await RabbitSendMessage("" , "" , "" , message , "" , 0 , sysid);
        }

        //private async void SendCommandMessage(List<string> sysid)
        //{
        //    await RabbitSendCommandMessage(cmdmessage, sysid);
        //}


    }
}
