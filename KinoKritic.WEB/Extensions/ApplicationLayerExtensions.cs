using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL;
using KinoKritic.WEB.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KinoKritic.WEB.Extensions
{
    public static class ApplicationLayerExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}