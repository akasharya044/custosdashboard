namespace custos.Models
{
	public class AdminUsers
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
	}

	public class AdminUsersDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Token { get; set; }
		public int Location { get; set; }
		public string FirstName { get; set; }
	}

	public static class getToken
	{
		public static string LoginToken { get; set; }

	}
}
