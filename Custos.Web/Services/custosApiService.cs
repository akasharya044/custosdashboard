

using custos.Models;

namespace custos.Web.Services
{
    public class custosApiService : IcustosApiService
    {
        readonly HttpClient _httpClient;
        public custosApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetData(string endpoint)
        {
            var response = new Response();
            try
            {
                
                var result = await _httpClient.GetAsync(endpoint);
                response = await result.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                response.Message = ex.Message;

            }

            return response;
        }
        public async Task<Response> PostData(object input, string endpoint)
        {
            Response response = new Response();
            try
            {
                
                var result = await _httpClient.PostAsJsonAsync(endpoint, input);
                response = await result.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Response> PutData(object input, string endpoint)
        {
            Response response = new Response();
            try
            {

                var result = await _httpClient.PutAsJsonAsync(endpoint, input);
                response = await result.Content.ReadFromJsonAsync<Response>();
            }
            catch (Exception ex)
            {
                response.Status = "Failed";
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<Stream> GetStreamData(object input, string endpoint)
        {
            try
            {
                var result = await _httpClient.PostAsJsonAsync(endpoint, input);
                var stream = await result.Content.ReadAsStreamAsync();
                return stream; //await result.Content.ReadFromJsonAsync<Stream>();
            }
            catch (Exception ex)
            {

                return null;
            }
            return null;
        }
    }
}
