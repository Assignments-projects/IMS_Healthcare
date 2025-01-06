using AuthLayer.Models;
using DbLayer.Data;
using DbLayer.Interfaces;
using DbLayer.Interfaces.Patients;
using DbLayer.Repositories;
using DbLayer.Repositories.Patients;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DbLayer
{
	public static class DbLayerConfig
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<IMSDbContext>(option => option.UseSqlServer(connectionString));

			services.AddIdentity<AppUser, IdentityRole>()
					.AddEntityFrameworkStores<IMSDbContext>()
					.AddDefaultTokenProviders();

			services.AddTransient<IUsersRepository, UserRepository>();
			services.AddTransient<IPatientsRepository, PatientsRepository>();
			services.AddTransient<IStaffsRepository, StaffsRepository>();

			return services;
        }
    }
}
