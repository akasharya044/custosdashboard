using custos.Models;
using custos.Models.RbacModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace custos.DAL.DataService
{
    public interface IRbacDataService
    {
        Task<Response> ValidateSignIn(LoginDTO masterDTO);
        Task<Response> CreateClient(ClientDTO clientDTO);
        Task<Response> GetAllClient();
        Task<Response> GetMenuById(int id);
        Task<Response> GetMenuList(int userTypeId, int UserId);
		Task<Response> GetClientLicence(int clientId);
		Task<Response> GetAllState();

        Task<Response> AgentRegistration(AgentRegistrationDTO data);
	}

}
