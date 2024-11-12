using Microsoft.AspNetCore.Identity;
using UniversityProject.Application;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure;
using UniversityProject.Infrastructure.Persistance;


namespace UniversityProject.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddApplication();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<DataContext>();
            

            var app = builder.Build();





            using(var scope = app.Services.CreateScope())
            {
                var roleManager  = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var roles = new[] { "Admin", "User" };

                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                        await roleManager.CreateAsync(new IdentityRole(role));
                }

            }



            using(var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var email = "admin@gmail.com";
                var password = "Admin@1234";

                if(await userManager.FindByEmailAsync(email) == null)
                {
                    var user = new ApplicationUser()
                    {
                        Email = email,
                        Full_name="Admin",
                        PhoneNumber="+998994731976",
                        country_id=1,
                        Is_deleted=false,
                        Password=password,
                        UserName = "Admin",
                        Role="Admin"


                    };

                    var result = await userManager.CreateAsync(user,password );
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }



            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
