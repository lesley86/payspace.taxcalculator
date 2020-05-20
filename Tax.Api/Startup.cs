using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tax.Api.Autofac;
using Tax.Core;
using Tax.Core.Exceptions;
using Tax.Core.Progressive;
using Tax.Core.Repositories;
using Tax.Core.Services;
using Tax.Persistence.EF;

namespace Tax.Api
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            // In ASP.NET Core 3.0 `env` will be an IWebHostEnvironment, not IHostingEnvironment.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set; }

        public ILifetimeScope AutofacContainer { get; private set; }

        // ConfigureServices is where you register dependencies. This gets
        // called by the runtime before the ConfigureContainer method, below.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the collection. Don't build or return
            // any IServiceProvider or the ConfigureContainer method
            // won't get called.
            services.AddControllers();
            services.AddOptions();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<TaxCalculationService>().As<ITaxCalculationService>().InstancePerLifetimeScope();
            builder.RegisterType<FlateRateCalculator>().AsSelf().As<ITaxTypeCalculator>().InstancePerLifetimeScope();
            builder.RegisterType<FlatValueCalculator>().AsSelf().As<ITaxTypeCalculator>().InstancePerLifetimeScope();
            builder.RegisterType<ProgressiveTaxCalculator>().AsSelf().As<ITaxTypeCalculator>().InstancePerLifetimeScope();
            builder.RegisterModule<ProgressiveTaxHandlers>();
            builder.RegisterType<CalculatedTaxRepository>().As<ICalculatedTaxRepostiory>().InstancePerLifetimeScope();
            builder.RegisterType<TaxContext>().WithParameter(
                new TypedParameter(typeof(string), Configuration["SqlServer:ConnectionString"])).AsSelf();

            builder.Register<Func<string, ITaxTypeCalculator>>(c =>
            {
                var cc = c.Resolve<IComponentContext>();
                return (string postalCode) =>
                {
                    switch (postalCode)
                    {
                        case "7441":
                        case "1000":
                            return cc.Resolve<ProgressiveTaxCalculator>();
                        case "A100":
                            return cc.Resolve<FlatValueCalculator>();
                        case "7000":
                            return cc.Resolve<FlateRateCalculator>();
                        default:
                            return null;
                    }
                };
            });
        }

        // Configure is where you add middleware. This is called after
        // ConfigureContainer. You can use IApplicationBuilder.ApplicationServices
        // here if you need to resolve things from the container.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/json";

                        var exceptionHandlerPathFeature =
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        await context.Response.WriteAsync("{");
                        if (exceptionHandlerPathFeature?.Error is ValidationException error)
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsync($"'errorMessage': '{error.Message}'");
                        }

                        await context.Response.WriteAsync("}");
                    });
                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
