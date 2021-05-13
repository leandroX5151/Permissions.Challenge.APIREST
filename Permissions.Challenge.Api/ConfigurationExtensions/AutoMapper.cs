using Permissions.Challenge.Api.Maps;
using Microsoft.Extensions.DependencyInjection;

namespace Permissions.Challenge.Api.ConfigurationExtensions
{
    public static class AutoMapper
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = AutoMapperConfigurator.Configure();
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(x => mapper);
            services.AddTransient<IAutoMapper, AutoMapperAdapter>();
        }
    }
}