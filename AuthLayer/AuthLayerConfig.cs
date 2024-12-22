using AuthLayer.Interfaces;
using AuthLayer.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthLayer
{
    public static class AuthLayerConfig
    {
        public static IServiceCollection AddAuthServices(this IServiceCollection services)
        {
			services.AddTransient<IAccountService, AccountService>();

			return services;
        }
    }
}
