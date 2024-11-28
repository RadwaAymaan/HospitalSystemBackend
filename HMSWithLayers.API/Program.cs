using Hangfire;
using HMSWithLayers.API.ExceptionHandlers;
using HMSWithLayers.API.ExtensionMethods;
using HMSWithLayers.API.Middlware;
using HMSWithLayers.API.Setting;
using HMSWithLayers.Application.Services;
using HMSWithLayers.Domain.Entities;
using HMSWithLayers.Infrastructure.BaseContext;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Diagnostics;

namespace HMSWithLayers.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Configuration.Sources.Clear();
            builder.Configuration.AddJsonFile("appsettings.json",optional: true, reloadOnChange: true);
            // Configure AppSettings
            builder.Configuration.Bind("AppSettings", builder.Configuration.GetSection("AppSettings"));
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

            // Add services to the container.
            builder.Host.UseSerilog((context, configuration) =>
              configuration.ReadFrom.Configuration(context.Configuration));

            builder.Services.AddExceptionHandler<ResourceNotFoundExceptionHandler>();
            builder.Services.AddExceptionHandler<AuthorizationExceptionHandler>();
            builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
            builder.Services.AddScoped(typeof(UserContextService));
            builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter your token"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

			builder.Services.AddHMSServices(builder.Configuration);

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
			       .AddEntityFrameworkStores<HMSBaseDbContext>();

            builder.Services.AddDbContext<HMSBaseDbContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionForSql"),
                        b => b.MigrationsAssembly("HMSWithLayers.Infrastructure.Sql")));

            //         builder.Services.AddDbContext<HMSBaseDbContext>(options =>
            //                   options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionForPostgresql")));

            //builder.Services.AddDbContext<HMSBaseDbContext>(options =>
            //		  options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnectionForMysql")));

            builder.Services.AddJwtAuthentication(builder);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOriginsPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.AddMiniProfiler(options =>
            {
                options.RouteBasePath = "/profiler";
            }).AddEntityFramework();

			var app = builder.Build();
            var appSettings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                builder.Configuration.AddUserSecrets<Program>();

                if (appSettings.EnableSwagger)
                {
                    // Enable Swagger
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    });
                }
            }
            if (appSettings.EnableMiddleware)
            {
                app.UseMiddleware<AuditLogMiddleware>();
            }
            app.UseExceptionHandler(opt => { });
            if (appSettings.EnableSerilog)
            {
                app.UseSerilogRequestLogging();
            }            
            app.UseHttpsRedirection();
			app.UseAuthentication();
            if (appSettings.EnableCors)
            {
                app.UseCors("AllowAllOriginsPolicy");
            }
            if (appSettings.EnableMiddleware)
            {
                app.UseMiddleware<UserScopeMiddleware>();
            }
            app.UseMiniProfiler();
            app.UseHangfireDashboard();         
            if (appSettings.EnableMiddleware)
            {
                app.UseMiddleware<UserScopeMiddleware>();
            }
            app.UseHangfireServer();
            app.UseAuthorization();
            app.MapGet("/", () => app.Configuration.AsEnumerable());
            app.MapControllers();
            app.Run();
		}
    }
}
