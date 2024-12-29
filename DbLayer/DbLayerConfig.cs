using AuthLayer.Models;
using DbLayer.Data;
using DbLayer.Interfaces;
using DbLayer.Repositories;
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


			return services;
        }
    }
}
