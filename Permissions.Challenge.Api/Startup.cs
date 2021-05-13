using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using Permissions.Challenge.Api.ConfigurationExtensions;
using Permissions.Challenge.Domain;
using Microsoft.AspNetCore.Mvc;
using Permissions.Challenge.Data.DAL;
using Permissions.Challenge.Transversal;

namespace Permissions.Challenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            _configuration = configuration;
        }

        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDataAccessLayer(_configuration);

            services.ConfigureAutoMapper();

            ConfigureDomain(services);

            var section = _configuration.GetSection("Settings");

            services.SetupCors(_configuration);
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseAuthentication();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


        private static void ConfigureDomain(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IPermisoDomain, PermisoDomain>();
            services.AddScoped<ITipoPermisoDomain, TipoPermisoDomain>();
        }
    }
}
