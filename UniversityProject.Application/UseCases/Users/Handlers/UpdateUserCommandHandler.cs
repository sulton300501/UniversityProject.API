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

        if (oldUser == null) throw new Exception("Foydalanuvchi topilmadi!");

        // Fayl va papkalarni yaratish
        var files = request.Picture;
        var path = Path.Combine(env.WebRootPath, "UserImage");
        Directory.CreateDirectory(path); // Papkani yaratish
        
        var fileName = "";

        if (files != null)
        {
            // Maksimal fayl o'lchami
            var maxFileSize = 5 * 1024 * 1024;
            if (files.Length > maxFileSize)
                throw new Exception("Fayl o'lchami ruxsat etilganidan oshib ketdi!");

            // Fayl kengaytmasi tekshiruvi
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg" };
            var extension = Path.GetExtension(files.FileName).ToLower();
            if (!allowedExtensions.Contains(extension))
                throw new Exception("Fayl turi noto'g'ri!");

            // Eski faylni o'chirish
            if (!string.IsNullOrEmpty(oldUser.PictureUrl))
            {
                var oldFilePath = Path.Combine(path, oldUser.PictureUrl);
                if (File.Exists(oldFilePath)) File.Delete(oldFilePath);
            }

            // Yangi faylni saqlash
            fileName = Guid.NewGuid() + extension;
            var filePath = Path.Combine(path, fileName);
            await using var stream = new FileStream(filePath, FileMode.Create);
            await files.CopyToAsync(stream, cancellationToken);
        }

        // Foydalanuvchini yangilash
        if (!string.IsNullOrEmpty(request.FullName))
            oldUser.FullName = request.FullName!;

        oldUser.PictureUrl = "/UserImage/"+fileName;

        if (request.CountryId.HasValue)
            oldUser.CountryId = request.CountryId.Value;

        context.Users.Update(oldUser);
        await context.SaveChangesAsync(cancellationToken);
        return oldUser;
    }
}

}
