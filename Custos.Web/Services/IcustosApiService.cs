

using custos.Models;

namespace custos.Web.Services
{
    public interface IcustosApiService
    {
        Task<Response> GetData(string endpoint);
        Task<Response> PostData(object input, string endpoint);
        Task<Stream> GetStreamData(object input, string endpoint);
        Task<Response> PutData(object input, string endpoint);
    }
}
