namespace LaborExchange.Models.Entities
{
	public class WorkerSpecialities
	{
		public int WorkerId { get; set; }
		public int SpecialityId { get; set; }

		public Specialities Speciality { get; set; }
		public Workers Worker { get; set; }
	}
}