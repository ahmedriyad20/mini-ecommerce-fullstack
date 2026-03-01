
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using MiniECommerce.Application;
using MiniECommerce.Application.Behaviors;
using MiniECommerce.Infrastructure;
using MiniECommerce.Infrastructure.Context;
using MiniECommerce.Service;

namespace MiniECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            #region Register DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MiniEcommerceDB"));
            });
            #endregion

            #region Register module Core, Infrastructure and Service dependencies
            builder.Services.AddModuleCoreDependencies();
            builder.Services.AddModuleInfrastructureDependencies();
            builder.Services.AddModuleServicesDependencies();
            builder.Services.AddValidatorsFromAssembly(typeof(ValidationBehavior<,>).Assembly);
            #endregion

            #region Configure CORS to allow requests from any origin
            builder.Services.AddCors(options =>
            {
                // Policy 1: Allow everything (for development)
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });

                // Policy 2: Restrict to specific origin (for production)
                options.AddPolicy("ProductionPolicy", builder =>
                {
                    builder.WithOrigins("https://myapp.com", "https://www.myapp.com")
                           .AllowAnyMethod()
                           .AllowAnyHeader()
                           .AllowCredentials();
                });

                // Policy 3: Read-only access
                options.AddPolicy("ReadOnly", builder =>
                {
                    builder.AllowAnyOrigin()
                           .WithMethods("GET")
                           .AllowAnyHeader();
                });
            });
            #endregion

            #region Swagger Setting to enable adding token
            builder.Services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ASP.NET10WebAPI",
                    Description = "Mini E-Commerce Project"
                });
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter Bearer",
                });
            });
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
