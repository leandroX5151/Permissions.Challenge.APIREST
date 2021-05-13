using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Permissions.Challenge.Api.ConfigurationExtensions
{
    public static class Cors
    {
        public static void SetupCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                        . AllowAnyMethod();
                        // .WithExposedHeaders("X-Pagination");
                });
            });
        }
    }
}