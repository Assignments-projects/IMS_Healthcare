using AuthLayer.Models;
using DbLayer.Models;
using DbLayer.Models.Patient;
using DbLayer.Models.Settings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Data
{
    public class IMSDbContext : IdentityDbContext<AppUser>
    {
        public IMSDbContext(DbContextOptions<IMSDbContext> options) : base(options)
        {           
        }

		public DbSet<User> Users                        { get; set; }

		public DbSet<Patients> Patients                 { get; set; }
		public DbSet<Disease> Diseases                  { get; set; }
		public DbSet<Prescription> Prescriptions        { get; set; }
		public DbSet<Staff> Staffs                      { get; set; }

		public DbSet<ImageType> ImageTypes              { get; set; }
		public DbSet<DiseaseType> DiseaseTypes          { get; set; }

		public DbSet<ViewUsersVsRoles> ViewUsersVsRoles { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
        {

			// Map the view to the model
			builder.Entity<ViewUsersVsRoles>().ToView("ViewUsersVsRoles").HasNoKey();

			// Configure the relationship between Patients and Staff
			builder.Entity<Patients>()
				   .HasOne(p => p.Staff)
				   .WithMany(s => s.Patient)
				   .HasForeignKey(p => p.InChargeuUud)
				   .HasPrincipalKey(s => s.UserUuid);

			// Configure the relationship between Disease and Patients
			builder.Entity<Disease>()
				   .HasOne(d => d.Patient)
				   .WithOne(p => p.Disease)
				   .HasForeignKey<Patients>(p => p.UserUuid)
				   .HasPrincipalKey<Disease>(d => d.PatientUuid);

			// Configure the relationship between Disease and staff
			builder.Entity<Disease>()
				   .HasOne(d => d.Doctor)
				   .WithMany(s => s.Diseases)
				   .HasForeignKey(d => d.DoctorId)
			       .HasPrincipalKey(s => s.UserUuid);

			// Configure the one-to-one relationship between Patients and User
			builder.Entity<Patients>()
					.HasOne(p => p.User)
					.WithOne()  
					.HasForeignKey<Patients>(p => p.UserUuid)
					.HasPrincipalKey<User>(u => u.UserUuid);

			// Configure the one-to-one relationship between Staff and User
			builder.Entity<Staff>()
					.HasOne(s => s.User)
					.WithOne()
					.HasForeignKey<Staff>(s => s.UserUuid)
					.HasPrincipalKey<User>(u => u.UserUuid);

			base.OnModelCreating(builder);
		}
    }
}
