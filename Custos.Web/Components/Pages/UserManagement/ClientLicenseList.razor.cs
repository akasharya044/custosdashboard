using custos.Models.RbacModel;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Radzen;

namespace custos.Web.Components.Pages.UserManagement
{
    public partial class ClientLicenseList
    {
        [Parameter]
        public string Id { get; set; }

        Guid clientId;


        List<ClientLicenseDTO>  clientLicenses = new List<ClientLicenseDTO>();
        Variant variant = Variant.Filled;

        bool loading { get; set; } = true;
        IEnumerable<int> pageSizeOptions = new int[] { 10, 20, 30 };

        protected override async Task OnInitializedAsync()
        {

            if (Guid.TryParse(Id, out clientId)) 
            {
                await LoadData();
            }
            await base.OnInitializedAsync();



        }
        private async Task LoadData()
        {


            var data = await custosapiservice.GetData($"/api/custos/users/{clientId}");
            if (data != null && data.Status == "Success")
            {
                clientLicenses = JsonConvert.DeserializeObject<List<ClientLicenseDTO>>(data.Data.ToString());

            }

        }

    }
}
