using custos.Models;

namespace Custos.DAL.DataService
{
	public interface IMachineRegistrationData
	{
		Task<Response> AddMachineRegistration(MachineRegistrationDto data);
		Task<Response> GetMachinesData();

    }
}
