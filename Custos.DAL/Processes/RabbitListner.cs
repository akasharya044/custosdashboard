using Microsoft.Extensions.Hosting;

namespace Custos.DAL.Processes
{
    public class RabbitListner : BackgroundService
    {
        readonly DeviceLogs _devicelogs;
        private readonly IBus _busControl;
        public RabbitListner(DeviceLogs deviceLogs,IBus bus)
        {
            _devicelogs = deviceLogs;
            _busControl = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Channel created");
            await _busControl.ReceiveAsync<string>("CustOsdashboarddataHb", x =>
            {
                Task.Run(() => { 
                    Console.Write("Message received " + x); 
                    MessageReceived(x);
                    }, stoppingToken);
            });
        }
        private void MessageReceived(string message)
        {
            try
            {
                _devicelogs.UpdateDevice(message);
            }
            catch (Exception ex)
            {

                LogWriter.LogWrite("Error in message received " + ex.Message);
            }
            
        }
    }
}
