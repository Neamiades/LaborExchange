using System.Collections.Generic;

namespace LaborExchange.Models.Entities
{
	public class PersonnelRequests
	{
		public PersonnelRequests()
		{
			Vacancies = new HashSet<Vacancies>();
		}

		public int Id { get; set; }
		public string Status { get; set; }
		public int EmployerId { get; set; }

		public Employers Employer { get; set; }
		public ICollection<Vacancies> Vacancies { get; set; }
	}
}