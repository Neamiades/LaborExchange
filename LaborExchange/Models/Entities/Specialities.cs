using System.Collections.Generic;

namespace LaborExchange.Models.Entities
{
	public class Specialities
	{
		public Specialities()
		{
			EmploymentApplicationSpecialities = new HashSet<EmploymentApplicationSpecialities>();
			RetrainingApplicationSpecialities = new HashSet<RetrainingApplicationSpecialities>();
			Vacancies = new HashSet<Vacancies>();
			WorkerSpecialities = new HashSet<WorkerSpecialities>();
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<EmploymentApplicationSpecialities> EmploymentApplicationSpecialities { get; set; }
		public ICollection<RetrainingApplicationSpecialities> RetrainingApplicationSpecialities { get; set; }
		public ICollection<Vacancies> Vacancies { get; set; }
		public ICollection<WorkerSpecialities> WorkerSpecialities { get; set; }
	}
}