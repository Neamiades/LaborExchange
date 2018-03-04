namespace LaborExchange.Models.Entities
{
	public class EmploymentApplicationSpecialities
	{
		public int EmploymentApplicationId { get; set; }
		public int SpecialityId { get; set; }

		public EmploymentApplications EmploymentApplication { get; set; }
		public Specialities Speciality { get; set; }
	}
}