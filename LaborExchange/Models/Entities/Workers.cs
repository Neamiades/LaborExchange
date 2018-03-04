using System.Collections.Generic;

namespace LaborExchange.Models.Entities
{
	public class Workers
	{
		public Workers()
		{
			WorkerSpecialities = new HashSet<WorkerSpecialities>();
		}

		public int Id { get; set; }
		public string Status { get; set; }
		public string Name { get; set; }
		public string Contacts { get; set; }
		public int? EmployerId { get; set; }

		public Employers Employer { get; set; }
		public EmploymentApplications EmploymentApplications { get; set; }
		public RetrainingApplications RetrainingApplications { get; set; }
		public ICollection<WorkerSpecialities> WorkerSpecialities { get; set; }
	}
}