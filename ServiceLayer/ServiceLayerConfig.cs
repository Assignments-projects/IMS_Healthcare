using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Interfaces.Patients;
using ServiceLayer.Services;
using ServiceLayer.Services.Patients;

namespace ServiceLayer
{
	public static class ServiceLayerConfig
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IPatientsService, PatientsService>();
			services.AddTransient<IStaffService, StaffService>();

			return services;
        }
    }
}
