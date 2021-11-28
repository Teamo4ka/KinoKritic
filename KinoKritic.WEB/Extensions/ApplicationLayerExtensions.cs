using KinoKritic.BLL.Interfaces;
using KinoKritic.BLL.Mapping;
using KinoKritic.BLL.Services;
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
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IMediaService, MediaService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IProfileService, ProfileService>();
            return services;
        }
    }
}