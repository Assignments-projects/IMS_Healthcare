using AuthLayer.Models;
using DbLayer.Data;
using DbLayer.Interfaces;
using DbLayer.Interfaces.Finance;
using DbLayer.Interfaces.Patient;
using DbLayer.Interfaces.Settings;
using DbLayer.Repositories;
using DbLayer.Repositories.Finance;
using DbLayer.Repositories.Patient;
using DbLayer.Repositories.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DbLayer
{
	public static class DbLayerConfig
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
			var connectionString = configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<IMSDbContext>(option => 
			{
				option.UseSqlServer(connectionString);
				option.UseLazyLoadingProxies(false);
			}, ServiceLifetime.Scoped);

			services.AddIdentity<AppUser, IdentityRole>()
					.AddEntityFrameworkStores<IMSDbContext>()
					.AddDefaultTokenProviders();

			services.AddTransient<IHomeRepository, HomeRepository>();
			services.AddTransient<IUsersRepository, UserRepository>();
			services.AddTransient<IStaffsRepository, StaffsRepository>();

			services.AddTransient<IPatientsRepository, PatientsRepository>();
			services.AddTransient<IDiseaseRepository, DiseaseRepository>();
			services.AddTransient<IImageRepository, ImageRepository>();
			services.AddTransient<IPrescriptionRepository, PrescriptionRepository>();

			services.AddTransient<IStatementRepository, StatementRepository>();
			services.AddTransient<IStatementItemRepository, StatementItemRepository>();

			services.AddTransient<IDiseaseTypeRepository, DiseaseTypeRepository>();
			services.AddTransient<IImageTypeRepository, ImageTypeRepository>();

			return services;
        }
    }
}
