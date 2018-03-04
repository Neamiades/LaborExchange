namespace LaborExchange.Models.Entities
{
	public class Vacancies
	{
		public int Id { get; set; }
		public int Salary { get; set; }
		public string Schedule { get; set; }
		public string Position { get; set; }
		public int EmployerId { get; set; }
		public int? PersonnelRequestId { get; set; }
		public int SpecialityId { get; set; }

		public Employers Employer { get; set; }
		public PersonnelRequests PersonnelRequest { get; set; }
		public Specialities Speciality { get; set; }
	}
}