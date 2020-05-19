using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static paymayAPI.Api.Configurations.AutoMapper;
using static paymayAPI.Api.Configurations.FluentValidation;
using static paymayAPI.Api.Configurations.MediatR;
using static paymayAPI.Api.Configurations.Mvc;
using static paymayAPI.Api.Configurations.Swagger;
using static paymayAPI.Api.Configurations.Db;
using paymayAPI.Persistence.Context;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace paymayAPI.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			RegisterEntityFramework(services, Configuration);
			RegisterSwagger(services);
            RegisterMediatR(services);
            RegisterAutoMapper(services);
            IMvcBuilder mvcBuilder = RegisterMvc(services);
            AddFluentValidation(mvcBuilder);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, paymayAPIDbContext context)
        {
            Console.WriteLine("Current Environment");
            Console.WriteLine(env.EnvironmentName);
            ConfigureSwagger(app);
            ConfigureMvc(app);
			ConfigureDatabaseMigrations(context);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
				SeedDatabase(context);
            }
        }
    }
}