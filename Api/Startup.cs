using Api.Middlewares;
using AutoMapper;
using Domain.Helpers;
using Infra.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Core;
using System;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configure Application Settings
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<MapBoxSettings>(Configuration.GetSection("MapBoxSettings"));
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<DatabaseSettings>(Configuration.GetSection("ConnectionStrings"));
            #endregion

            services.AddDbContext<DatabaseContext>();

            services.ConfigureDependencies();

            services.AddCors();

            services.AddMemoryCache();

            services.AddControllers().AddJsonOptions(o =>
            {
                o.JsonSerializerOptions.PropertyNamingPolicy = null;
                o.JsonSerializerOptions.DictionaryKeyPolicy = null;
            });

            Logger logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            services.AddSingleton(logger);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<Middlewares.AuthenticationMiddleware>();

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}