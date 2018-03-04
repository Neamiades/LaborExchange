namespace LaborExchange.Models.Entities
{
	public class RetrainingApplicationSpecialities
	{
		public int RetrainingApplicationId { get; set; }
		public int SpecialityId { get; set; }

		public RetrainingApplications RetrainingApplication { get; set; }
		public Specialities Speciality { get; set; }
	}
}