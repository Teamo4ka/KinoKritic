using KinoKritic.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KinoKritic.WEB.Extensions
{
    public static class DALExtensions
    {
        public static IServiceCollection AddDataLayerServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });


            return services;
        }
    }
}