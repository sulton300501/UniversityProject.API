using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Handlers
{
    public class UpdateUserCommandHandler(DataContext context, IWebHostEnvironment env)
        : IRequestHandler<UpdateUserCommand, ApplicationUser>
    {
        public async Task<ApplicationUser> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await context.Users
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (oldUser == null) throw new Exception("User not found!");
            
            // Fayl va papkalarni yaratish
            var files = request.Picture;
            var path = Path.Combine(env.WebRootPath, "UserImage");
            Directory.CreateDirectory(path); // Papkani yaratish
            
            var fileName = "";

            if (files != null)
            {
                // Eski faylni o'chirish
                if (!string.IsNullOrEmpty(oldUser.PictureUrl))
                {
                    var oldFilePath = Path.Combine(path, oldUser.PictureUrl);
                    if (File.Exists(oldFilePath)) File.Delete(oldFilePath);
                }

                // Yangi faylni saqlash
                fileName = "/UserImage/"+Guid.NewGuid() + Path.GetExtension(files.FileName);
                var filePath = Path.Combine(path, fileName);
                await using var stream = new FileStream(filePath, FileMode.Create);
                await files.CopyToAsync(stream, cancellationToken);
            }

            // Foydalanuvchini yangilash
            
            // FullName tekshiruvi
            if (!string.IsNullOrEmpty(request.FullName))
                oldUser.FullName = request.FullName!;
            
            oldUser.PictureUrl = fileName;

            if (request.CountryId.HasValue)
                oldUser.CountryId = request.CountryId.Value;

            context.Users.Update(oldUser);
            await context.SaveChangesAsync(cancellationToken);
            return oldUser;
        }
    }
}
