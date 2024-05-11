using custos.Models;
using Custos.DAL.Unitofworks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Json;

namespace Custos.DAL.Processes
{
	public class DeviceLogs
	{
		private List<DeviceStatusPool> _devices = new List<DeviceStatusPool>();
		private readonly IServiceScopeFactory _serviceScopeFactory;
		private readonly IBus _buscontrol;
		int lastid = 0;
		DateTime lastprocessdate = DateTime.Now;
		DateTime lastGetTickets = DateTime.Now.AddDays(-1);
		bool processing = false;
		int totaldevices = 0;
		int runningdevices = 0;
		public DeviceLogs(IServiceScopeFactory serviceScopeFactory, IBus buscontrol)
		{
			_serviceScopeFactory = serviceScopeFactory;
            SetupCleanUpTask();
            _buscontrol = buscontrol;


		}

		public async Task CheckDeviceAddition()
		{
			try
			{
				using (var scope = _serviceScopeFactory.CreateScope())
				{
					var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWorks>();
					var lastrecord = uow.deviceDetails.GetAllNoTracking(null, x => x.OrderByDescending(x => x.Id)).FirstOrDefault();
					if (lastrecord != null)
					{
						

							foreach (var device in uow.registerdevice.GetSelectedNoTracking(x => x.DisplayLabel, x => (x.SubType == "Laptop" || x.SubType == "Desktop")).Distinct())
							{
							if(!_devices.Where(d=>d.DeviceId==device).Any())
								_devices.Add(new DeviceStatusPool { DeviceId = device, IsRunning = false, LastHeartBeat = DateTime.Now.AddDays(-1) });


							}
							totaldevices = _devices.Count;
							lastid = lastrecord.Id;

					}
					runningdevices = _devices.Where(x => x.IsRunning).Count();
				}
			}
			catch (Exception ex)
			{
				//LogWriter.LogWrite($"{ex.Message}");

			}
		}
		

		public void UpdateDevice(string machineid)
		{
			foreach (var item in _devices.Where(x => x.DeviceId.ToLower().Equals(machineid.ToLower())))
			{
				item.IsRunning = true;
				item.LastHeartBeat = DateTime.Now;
			}
			runningdevices = _devices.Where(x => x.IsRunning).Count();
		}
		public List<DeviceStatusPool> GetDevicePool()
		{
			return _devices;
		}
	
		
        private void SetupCleanUpTask()
        {

            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        foreach (var item in _devices.Where(x => x.LastHeartBeat.AddMinutes(2) < DateTime.Now))
                        {
                            item.IsRunning = false;
                        }

                        await CheckDeviceAddition();
                        var data = new DeviceStatusDto
                        {
                            TotalDevices = totaldevices,
                            RunningDevices = runningdevices
                        };
                       
                        await _buscontrol.CreateExchange<DeviceStatusDto>("CustOsdashboarddata", data);

                    }
                    catch (Exception ex)
                    {

                        LogWriter.LogWrite("DeviceLog Error " + ex.Message);
                    }


                    await Task.Delay(120000);
                }
            });
        }


    }
}
