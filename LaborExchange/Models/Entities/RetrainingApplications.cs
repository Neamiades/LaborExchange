using System.Collections.Generic;

namespace LaborExchange.Models.Entities
{
	public class RetrainingApplications
	{
		public RetrainingApplications()
		{
			RetrainingApplicationSpecialities = new HashSet<RetrainingApplicationSpecialities>();
		}

		public int Id { get; set; }
		public string Status { get; set; }

		public Workers IdNavigation { get; set; }
		public ICollection<RetrainingApplicationSpecialities> RetrainingApplicationSpecialities { get; set; }
	}
}