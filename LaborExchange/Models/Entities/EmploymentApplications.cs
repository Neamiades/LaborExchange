using System.Collections.Generic;

namespace LaborExchange.Models.Entities
{
	public class EmploymentApplications
	{
		public EmploymentApplications()
		{
			EmploymentApplicationSpecialities = new HashSet<EmploymentApplicationSpecialities>();
		}

		public int Id { get; set; }
		public string Status { get; set; }

		public Workers IdNavigation { get; set; }
		public ICollection<EmploymentApplicationSpecialities> EmploymentApplicationSpecialities { get; set; }
	}
}