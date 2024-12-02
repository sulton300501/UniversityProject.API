using MediatR;
using Microsoft.AspNetCore.Hosting;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Handlers
{
    public class CreateUserCommandHandler(DataContext context, IWebHostEnvironment env)
        : IRequestHandler<CreateUserCommands, ApplicationUser>
    {
        public async Task<ApplicationUser> 
            Handle(CreateUserCommands request, CancellationToken cancellationToken)
        {
            // Muallif ma'lumotlarini yaratish
            var data = new ApplicationUser()
            {
                FullName = request.FullName,
                CreatedAt = DateTime.UtcNow,
                CountryId = request.CountryId,
                PhoneNumber = request.PhoneNumber!,
                Email = request.Email,
                Password = request.Password
            };
            
            // Fayl mavjudligini tekshirish
            if (request.Picture != null)
            {
                // WebRootPath ni tekshirish
                if (string.IsNullOrEmpty(env.WebRootPath))
                {
                    // wwwroot katalogi yo'q bo'lsa, uni yaratish
                    var rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                    if (!Directory.Exists(rootPath))
                        Directory.CreateDirectory(rootPath);
                    
                    env.WebRootPath = rootPath; // Yangi yaratilgan yo'lni o'rnatish
                }

                var files = request.Picture;
                var validExtensions = new[] { ".jpg", ".png", ".jpeg" };

                // Fayl turi va hajmini tekshirish
                if (!validExtensions.Contains(Path.GetExtension(files.FileName).ToLower()))
                    throw new Exception("Noto'g'ri fayl turi. Faqat JPG, PNG va JPEG formatlariga ruxsat berilgan.");

                if (files.Length > 5 * 1024 * 1024) // Maksimal hajm: 5 MB
                    throw new Exception("Fayl hajmi 5 MB dan oshmasligi kerak.");

                // Fayl yo'lini yaratish
                var path = Path.Combine(env.WebRootPath, "UserImage");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                // Fayl nomini generatsiya qilish
                var fileName = $"{Guid.NewGuid()}-UserImage{Path.GetExtension(files.FileName)}";
                var filePath = Path.Combine(path, fileName);
                
                // Faylni saqlash
                using (var stream = new FileStream(filePath, FileMode.Create))
                    await files.CopyToAsync(stream);
                
                data.PictureUrl = fileName;
            }

            // Ma'lumotlar bazasiga saqlash
            await context.Users.AddAsync(data, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return data;
        }
    }
}
