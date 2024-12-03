﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services , IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(config.GetConnectionString("Db"))
                    .LogTo(Console.WriteLine, LogLevel.Warning); // Faqat Warning va undan yuqori loglar;
            });

            return services;
        }
    }
}
