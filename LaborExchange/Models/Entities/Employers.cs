using System.Collections.Generic;

namespace LaborExchange.Models.Entities
{
	public class Employers
	{
		public Employers()
		{
			PersonnelRequests = new HashSet<PersonnelRequests>();
			Vacancies = new HashSet<Vacancies>();
			Workers = new HashSet<Workers>();
		}

		public int Id { get; set; }

		public string Status { get; set; }

		public string Name { get; set; }

		public string Contacts { get; set; }


		public ICollection<PersonnelRequests> PersonnelRequests { get; set; }

		public ICollection<Vacancies> Vacancies { get; set; }

		public ICollection<Workers> Workers { get; set; }
	}
}