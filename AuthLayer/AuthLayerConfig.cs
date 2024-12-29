using AuthLayer.Interfaces;
using AuthLayer.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AuthLayer
{
    public static class AuthLayerConfig
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<IRoleService, RoleService>();

			return services;
        }
    }
}
