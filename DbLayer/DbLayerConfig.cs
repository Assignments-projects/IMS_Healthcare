using AuthLayer.Models;
using DbLayer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			return services;
        }
    }
}
