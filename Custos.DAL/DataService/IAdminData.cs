using custos.Models;
namespace Custos.DAL.DataService
{
	public interface IAdminData
    {
       // Task<Response> GetTestList();
       // Task<Response> UpsertTest(TestDTO test);
        Task<Response> Login(AdminUsersDto data);
        Task<Response> UpsertAdminUsers(AdminUsersDto data);
		Task<Response> Logindashboard(AdminUsersDto data);


	}
}
