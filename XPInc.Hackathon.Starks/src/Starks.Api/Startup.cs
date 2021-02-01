using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Starks.Api.Infrastructure.Filters;
using System;
using System.Reflection;
using XPInc.Hackathon.Starks.Application.Queries.Manager;
using XPInc.Hackathon.Starks.Application.Queries.Team;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.ManagerAggregate;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.TeamAggregate;
using XPInc.Hackathon.Starks.Infrastructure;
using XPInc.Hackathon.Starks.Infrastructure.Repositories;
using MediatR;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.FollowupAggregate;
using Starks.Infrastructure.TwiiloAdapter;
using XPInc.Hackathon.Starks.Domain.AggregatesModel.AlertAggregate;

namespace Starks.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomMvc()
                .AddCustomSwagger()
                .AddMediatR()
                .AddCustomDbContext(Configuration);

            services.AddSingleton<IManagerQueries, ManagerQueries>();
            services.AddSingleton<ITeamQueries, TeamQueries>();

            services.AddSingleton<IManagerRepository, ManagerRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();
            services.AddSingleton<IAlertRepository, AlertRepository>();

            services.AddSingleton<IFollowupAdapter, TwiiloCalls>();

            services.AddSingleton(
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSwagger()
               .UseSwaggerUI(c =>
               {
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "Starks APIs V1");
                   c.RoutePrefix = string.Empty;
               });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    static class CustomExtensionsMethods
    {
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            ;

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .SetIsOriginAllowed((host) => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return services;
        }

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<StarksContext>(options =>
                   {
                       options.UseSqlServer(configuration["ConnectionString"],
                           sqlServerOptionsAction: sqlOptions =>
                           {
                               sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                               sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                           });
                   },
                       ServiceLifetime.Singleton
                   );

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                //options.EnableAnnotations();

                options.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.ActionDescriptor.RouteValues}");
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "XPInc Starks APIs",
                    Description = "APIs do microserviço Stark",
                    TermsOfService = null,
                    Contact = new OpenApiContact
                    {
                        Name = "Danilo N Kawanishi",
                        Email = "danilo.kawanishi@xpi.com.br",
                        Url = new Uri("https://xpi.com.br")
                    },
                });
            });

            return services;
        }

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("Starks.Application");

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

            services.AddMediatR(assembly);

            return services;
        }
    }
}
