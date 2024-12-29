using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace ServiceLayer
{
    public static class ServiceLayerConfig
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
			services.AddTransient<IUserService, UserService>();

			return services;
        }
    }
}
