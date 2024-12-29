using AuthLayer.Models;
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

		public DbSet<ViewUsersVsRoles> ViewUsersVsRoles { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
        {

			// Map the view to the model
			builder.Entity<ViewUsersVsRoles>().ToView("ViewUsersVsRoles").HasNoKey();

			base.OnModelCreating(builder);
		}
    }
}
