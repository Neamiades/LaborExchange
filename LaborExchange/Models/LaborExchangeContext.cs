using System.Configuration;
using LaborExchange.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace LaborExchange.Models
{
	public class LaborExchangeContext : DbContext
	{
	    public virtual DbSet<Employers> Employers { get; set; }
	    public virtual DbSet<EmploymentApplications> EmploymentApplications { get; set; }
	    public virtual DbSet<EmploymentApplicationSpecialities> EmploymentApplicationSpecialities { get; set; }
	    public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
	    public virtual DbSet<PersonnelRequests> PersonnelRequests { get; set; }
	    public virtual DbSet<RetrainingApplications> RetrainingApplications { get; set; }
	    public virtual DbSet<RetrainingApplicationSpecialities> RetrainingApplicationSpecialities { get; set; }
	    public virtual DbSet<Specialities> Specialities { get; set; }
	    public virtual DbSet<Vacancies> Vacancies { get; set; }
	    public virtual DbSet<Workers> Workers { get; set; }
	    public virtual DbSet<WorkerSpecialities> WorkerSpecialities { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Employers>(entity =>
			{
				entity.Property(e => e.Contacts).IsRequired();

				entity.Property(e => e.Name).IsRequired();

				entity.Property(e => e.Status).IsRequired();
			});

			modelBuilder.Entity<EmploymentApplications>(entity =>
			{
				entity.HasIndex(e => e.Id)
					.HasName("IX_Id");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.Status).IsRequired();

				entity.HasOne(d => d.IdNavigation)
					.WithOne(p => p.EmploymentApplications)
					.HasForeignKey<EmploymentApplications>(d => d.Id)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_dbo.EmploymentApplications_dbo.Workers_Id");
			});

			modelBuilder.Entity<EmploymentApplicationSpecialities>(entity =>
			{
				entity.HasKey(e => new {e.EmploymentApplicationId, e.SpecialityId});

				entity.HasIndex(e => e.EmploymentApplicationId)
					.HasName("IX_EmploymentApplication_Id");

				entity.HasIndex(e => e.SpecialityId)
					.HasName("IX_Speciality_Id");

				entity.Property(e => e.EmploymentApplicationId).HasColumnName("EmploymentApplication_Id");

				entity.Property(e => e.SpecialityId).HasColumnName("Speciality_Id");

				entity.HasOne(d => d.EmploymentApplication)
					.WithMany(p => p.EmploymentApplicationSpecialities)
					.HasForeignKey(d => d.EmploymentApplicationId)
					.HasConstraintName("FK_dbo.EmploymentApplicationSpecialities_dbo.EmploymentApplications_EmploymentApplication_Id");

				entity.HasOne(d => d.Speciality)
					.WithMany(p => p.EmploymentApplicationSpecialities)
					.HasForeignKey(d => d.SpecialityId)
					.HasConstraintName("FK_dbo.EmploymentApplicationSpecialities_dbo.Specialities_Speciality_Id");
			});

			modelBuilder.Entity<MigrationHistory>(entity =>
			{
				entity.HasKey(e => new {e.MigrationId, e.ContextKey});

				entity.ToTable("__MigrationHistory");

				entity.Property(e => e.MigrationId).HasMaxLength(150);

				entity.Property(e => e.ContextKey).HasMaxLength(300);

				entity.Property(e => e.Model).IsRequired();

				entity.Property(e => e.ProductVersion)
					.IsRequired()
					.HasMaxLength(32);
			});

			modelBuilder.Entity<PersonnelRequests>(entity =>
			{
				entity.HasIndex(e => e.EmployerId)
					.HasName("IX_Employer_Id");

				entity.Property(e => e.EmployerId).HasColumnName("Employer_Id");

				entity.Property(e => e.Status).IsRequired();

				entity.HasOne(d => d.Employer)
					.WithMany(p => p.PersonnelRequests)
					.HasForeignKey(d => d.EmployerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_dbo.PersonnelRequests_dbo.Employers_Employer_Id");
			});

			modelBuilder.Entity<RetrainingApplications>(entity =>
			{
				entity.HasIndex(e => e.Id)
					.HasName("IX_Id");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.Status).IsRequired();

				entity.HasOne(d => d.IdNavigation)
					.WithOne(p => p.RetrainingApplications)
					.HasForeignKey<RetrainingApplications>(d => d.Id)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_dbo.RetrainingApplications_dbo.Workers_Id");
			});

			modelBuilder.Entity<RetrainingApplicationSpecialities>(entity =>
			{
				entity.HasKey(e => new {e.RetrainingApplicationId, e.SpecialityId});

				entity.HasIndex(e => e.RetrainingApplicationId)
					.HasName("IX_RetrainingApplication_Id");

				entity.HasIndex(e => e.SpecialityId)
					.HasName("IX_Speciality_Id");

				entity.Property(e => e.RetrainingApplicationId).HasColumnName("RetrainingApplication_Id");

				entity.Property(e => e.SpecialityId).HasColumnName("Speciality_Id");

				entity.HasOne(d => d.RetrainingApplication)
					.WithMany(p => p.RetrainingApplicationSpecialities)
					.HasForeignKey(d => d.RetrainingApplicationId)
					.HasConstraintName("FK_dbo.RetrainingApplicationSpecialities_dbo.RetrainingApplications_RetrainingApplication_Id");

				entity.HasOne(d => d.Speciality)
					.WithMany(p => p.RetrainingApplicationSpecialities)
					.HasForeignKey(d => d.SpecialityId)
					.HasConstraintName("FK_dbo.RetrainingApplicationSpecialities_dbo.Specialities_Speciality_Id");
			});

			modelBuilder.Entity<Specialities>(entity => { entity.Property(e => e.Name).IsRequired(); });

			modelBuilder.Entity<Vacancies>(entity =>
			{
				entity.HasIndex(e => e.EmployerId)
					.HasName("IX_Employer_Id");

				entity.HasIndex(e => e.PersonnelRequestId)
					.HasName("IX_PersonnelRequest_Id");

				entity.HasIndex(e => e.SpecialityId)
					.HasName("IX_Speciality_Id");

				entity.Property(e => e.Id).ValueGeneratedNever();

				entity.Property(e => e.EmployerId).HasColumnName("Employer_Id");

				entity.Property(e => e.PersonnelRequestId).HasColumnName("PersonnelRequest_Id");

				entity.Property(e => e.SpecialityId).HasColumnName("Speciality_Id");

				entity.HasOne(d => d.Employer)
					.WithMany(p => p.Vacancies)
					.HasForeignKey(d => d.EmployerId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_dbo.Vacancies_dbo.Employers_Employer_Id");

				entity.HasOne(d => d.PersonnelRequest)
					.WithMany(p => p.Vacancies)
					.HasForeignKey(d => d.PersonnelRequestId)
					.HasConstraintName("FK_dbo.Vacancies_dbo.PersonnelRequests_PersonnelRequest_Id");

				entity.HasOne(d => d.Speciality)
					.WithMany(p => p.Vacancies)
					.HasForeignKey(d => d.SpecialityId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("FK_dbo.Vacancies_dbo.Specialities_Speciality_Id");
			});

			modelBuilder.Entity<Workers>(entity =>
			{
				entity.HasIndex(e => e.EmployerId)
					.HasName("IX_Employer_Id");

				entity.Property(e => e.Contacts).IsRequired();

				entity.Property(e => e.EmployerId).HasColumnName("Employer_Id");

				entity.Property(e => e.Name).IsRequired();

				entity.Property(e => e.Status).IsRequired();

				entity.HasOne(d => d.Employer)
					.WithMany(p => p.Workers)
					.HasForeignKey(d => d.EmployerId)
					.HasConstraintName("FK_dbo.Workers_dbo.Employers_Employer_Id");
			});

			modelBuilder.Entity<WorkerSpecialities>(entity =>
			{
				entity.HasKey(e => new {e.WorkerId, e.SpecialityId});

				entity.HasIndex(e => e.SpecialityId)
					.HasName("IX_Speciality_Id");

				entity.HasIndex(e => e.WorkerId)
					.HasName("IX_Worker_Id");

				entity.Property(e => e.WorkerId).HasColumnName("Worker_Id");

				entity.Property(e => e.SpecialityId).HasColumnName("Speciality_Id");

				entity.HasOne(d => d.Speciality)
					.WithMany(p => p.WorkerSpecialities)
					.HasForeignKey(d => d.SpecialityId)
					.HasConstraintName("FK_dbo.WorkerSpecialities_dbo.Specialities_Speciality_Id");

				entity.HasOne(d => d.Worker)
					.WithMany(p => p.WorkerSpecialities)
					.HasForeignKey(d => d.WorkerId)
					.HasConstraintName("FK_dbo.WorkerSpecialities_dbo.Workers_Worker_Id");
			});
		}
	}
}