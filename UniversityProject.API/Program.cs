using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using UniversityProject.Application;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure;

namespace UniversityProject.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container
            ConfigureServices(builder);

            var app = builder.Build();

            // Configure the HTTP request pipeline
            ConfigureMiddleware(app);

            // Run the application
            await app.RunAsync();
        }
        
        // Misol ma'lumotlar uchun filter
        public class SwaggerExampleSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type == typeof(RegisterDTO))
                {
                    schema.Example = new OpenApiObject
                    {
                        ["Email"] = new OpenApiString("tohirjonodilov08@example.com"),
                        ["Password"] = new OpenApiString("SecurePassword123"),
                        ["Full_name"] = new OpenApiString("John Doe")
                    };
                }
            }
        }

        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SchemaFilter<SwaggerExampleSchemaFilter>();
                
                // API haqida ma'lumot
                c.SwaggerDoc("Main", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "MOI.Book online library API",
                    Version = "v1",
                    Description = "MOI.Book online library API provides endpoints for managing the application.",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Support Team",
                        Email = "tohirjon.software@gmail.com",
                        Url = new Uri("https://support.universityproject.com")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
                
                // Authentication gruppasini qo'shing
                c.SwaggerDoc("Authentication", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Authentication API",
                    Version = "v1",
                    Description = "API endpoints for authentication and user management."
                });

                // JWT autentifikatsiya
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your token."
                });

                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                
                // Add BasePath configuration

                c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
                {
                    Url = "http://localhost:5142", // Lokal server URL
                    Description = "Local Development Server"
                });
                
                c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
                {
                    Url = "https://app.tohirjon.uz", // O'zingizning base URL ni kiriting
                    Description = "Production Server"
                });

                c.AddServer(new Microsoft.OpenApi.Models.OpenApiServer
                {
                    Url = "https://staging-api.example.com", // Staging server uchun
                    Description = "Staging Server"
                });
                
                // Annotatsiyalarni yoqish
                c.EnableAnnotations();
            });


            // Add custom services
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();

            // Add CORS policy for frontend/backend communication
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            // Add API versioning
            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });
        }

        private static void ConfigureMiddleware(WebApplication app)
        {
            // Enable Swagger in development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/Main/swagger.json", "MOI.Book online library API v1");
                    c.SwaggerEndpoint("/swagger/Authentication/swagger.json", "Authentication API v1");
                    c.RoutePrefix = string.Empty; // Root URL'da ochiladi
                    c.DefaultModelsExpandDepth(-1); // Modellar avtomatik kengaytirilmaydi
                });
            }

            // Enable middleware for HTTPS redirection and static files
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable CORS
            app.UseCors("AllowAll");

            // Enable authentication and authorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Map controllers
            app.MapControllers();
        }
    }
}
