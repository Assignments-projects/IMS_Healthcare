using AuthLayer.Models;
using DbLayer.Models;
using DbLayer.Models.Finance;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DbLayer.Helpers;

namespace DbLayer.Data
{
    public class IMSDbContext : IdentityDbContext<AppUser>
    {
        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options)
        {           
        }

		// Application users and staffs db sets
		public DbSet<User> Users                        { get; set; }
		public DbSet<Staff> Staffs                      { get; set; }

		// App settings db sets
		public DbSet<ImageType> ImageTypes              { get; set; }
		public DbSet<DiseaseType> DiseaseTypes          { get; set; }
		public DbSet<OsSection> OsSections              { get; set; }
		public DbSet<OsStatus> OsStatuss                { get; set; }

		// Patients related db sets
		public DbSet<Patients> Patients                 { get; set; }
		public DbSet<Disease> Diseases                  { get; set; }
		public DbSet<Prescription> Prescriptions        { get; set; }
		public DbSet<Image> Images                      { get; set; }

		// Financial related sb sets
		public DbSet<Statement> Statements              { get; set; }
		public DbSet<StatementItem> StatementItems      { get; set; }

		// Views db sets
		public DbSet<ViewUsersVsRoles> ViewUsersVsRoles { get; set; }

		
		/// <summary>
		/// Perform entity set relationship or any other operation with db on model creation
		/// </summary>
		/// <param name="builder"></param>
		protected override void OnModelCreating(ModelBuilder builder)
        {

			// Map the view to the model
			builder.Entity<ViewUsersVsRoles>().ToView("ViewUsersVsRoles").HasNoKey();

			// Configure the relationship between Patients and Staff
			builder.Entity<Patients>()
				   .HasOne(p => p.Staff)
				   .WithMany(s => s.Patient)
				   .HasForeignKey(p => p.InChargeuUud)
				   .HasPrincipalKey(s => s.StaffUuid)
				   .IsRequired(false);

			// Configure the relationship between Disease and Patients
			builder.Entity<Disease>()
				   .HasOne(d => d.Patient)
				   .WithMany(p => p.Disease)
				   .HasForeignKey(p => p.PatientUuid)
				   .HasPrincipalKey(d => d.PatientUuid);

			// Configure the relationship between Disease and staff
			builder.Entity<Disease>()
				   .HasOne(d => d.Doctor)
				   .WithMany(s => s.Diseases)
				   .HasForeignKey(d => d.DoctorId)
			       .HasPrincipalKey(s => s.StaffUuid)
				   .IsRequired(false);

			// Configure the one-to-one relationship between Patients and User
			builder.Entity<Patients>()
					.HasOne(p => p.User)
					.WithOne()  
					.HasForeignKey<Patients>(p => p.PatientUuid)
					.HasPrincipalKey<User>(u => u.UserUuid)
					.OnDelete(DeleteBehavior.Restrict);

			// Configure the one-to-one relationship between Staff and User
			builder.Entity<Staff>()
					.HasOne(s => s.User)
					.WithOne()
					.HasForeignKey<Staff>(s => s.StaffUuid)
					.HasPrincipalKey<User>(u => u.UserUuid);

			// Configure the relationship between Statement and Patient
			builder.Entity<Statement>()
				   .HasOne(s => s.Patient)
				   .WithMany()
				   .HasForeignKey(s => s.PatientUuid)
				   .HasPrincipalKey(p => p.PatientUuid);


			// Configure audit relationship
			builder.AddAuditRelationship<Staff>();
			builder.AddAuditRelationship<Disease>();
			builder.AddAuditRelationship<Image>();
			builder.AddAuditRelationship<Patients>();
			builder.AddAuditRelationship<Prescription>();
			builder.AddAuditRelationship<Statement>();
			builder.AddAuditRelationship<StatementItem>();
			builder.AddAuditRelationship<ImageType>();
			builder.AddAuditRelationship<DiseaseType>();
			builder.AddAuditRelationship<OsSection>();
			builder.AddAuditRelationship<OsStatus>();

			base.OnModelCreating(builder);
		}


	}
}
