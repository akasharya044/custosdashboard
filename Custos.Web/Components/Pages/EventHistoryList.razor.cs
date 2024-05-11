
using custos.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Radzen;
using System.Reflection.Metadata;
using System.Text;

namespace custos.Web.Components.Pages
{
	public partial class EventHistoryList
	{
		List<EventHistoryDtoNew> _eventHistory { get; set; } = new List<EventHistoryDtoNew>();
		bool loading { get; set; } = true;
		IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };


		[Parameter]
		public string EventName { get; set; }

		Variant variant = Variant.Filled;

		protected override async Task OnInitializedAsync()
		{
			if (sessionData.UserData == null || sessionData.UserData.UserName == null)
				NavigationManager.NavigateTo("/");

			await base.OnInitializedAsync();
			await CountEvenData();
		}
		private async Task DownloadCsvEvent()
		{
			// Generate CSV content based on ticketData
			var csvContent = GenerateCsvContentEvent(_eventHistory);

			// Prepare the file content for download
			var data = Encoding.UTF8.GetBytes(csvContent);

			// Initiate the file download using FileSaver
			await JSRuntime.InvokeVoidAsync("saveAsFile", EventName + "_Record.csv", data, "text/csv");
			//ticketData = ticketData1;
		}


		private string GenerateCsvContentEvent(IEnumerable<EventHistoryDtoNew> data)
		{
			// Generate CSV content based on your data structure
			StringBuilder csvContent = new StringBuilder();

			// Add header row
			var headers = typeof(EventHistoryDtoNew).GetProperties().Select(property => property.Name);
			csvContent.AppendLine(string.Join(",", headers));

			// Add data rows
			foreach (var item in data)
			{
				var values = typeof(EventHistoryDtoNew).GetProperties().Select(property => property.GetValue(item)?.ToString() ?? "");
				csvContent.AppendLine(string.Join(",", values));
			}

			return csvContent.ToString();
		}
		public async Task CountEvenData()
		{

			try
			{
				var output = await custosapiservice.GetData("api/eventHistory/evenname/" + EventName);
				if (output != null && output.Status == "Success")
				{
					_eventHistory = JsonConvert.DeserializeObject<List<EventHistoryDtoNew>>(output.Data.ToString());
					loading = false;
					StateHasChanged();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}


	}
}
