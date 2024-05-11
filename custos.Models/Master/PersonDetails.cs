
using System.ComponentModel.DataAnnotations;

namespace custos.Modelss
{
    public class PersonDetails
    {
        [Key]
        public int Id { get; set; }
        public string? entity_type { get; set; }
        public bool IsDeleted { get; set; }
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmployeeNumber { get; set; }
        public bool IsVIP { get; set; }
        public string? Name { get; set; }
        public string? Upn { get; set; }
        public long LastUpdateTime { get; set; }
        public int Location { get; set; }

    }

    public class PersonDetailsDto
    {
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string? LastName { get; set; }
		public string FullName => FirstName + " " + LastName;

	}
	public class Properties
	{
		public int Id { get; set; }
		public bool IsDeleted { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmployeeNumber { get; set; }
		public bool IsVIP { get; set; }
		public string Name { get; set; }
		public string Upn { get; set; }
		public long LastUpdateTime { get; set; }

	}
}
