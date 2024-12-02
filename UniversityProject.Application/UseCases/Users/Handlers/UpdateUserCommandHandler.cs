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
            
            var files = request.Picture;
            var path = Path.Combine(env.WebRootPath, "UserImage");
            var fileName = "";

            if (files != null)
            {
                if (!string.IsNullOrEmpty(oldUser!.PictureUrl))
                {
                    var oldFilePath = Path.Combine(path , oldUser.PictureUrl);
                    if(File.Exists(oldFilePath)) File.Delete(oldFilePath);
                }
                
                fileName = Guid.NewGuid() + Path.GetExtension(files.FileName);
                var filePath = Path.Combine(path, fileName);
                await using var stream =new FileStream(filePath , FileMode.Create);
                await stream.CopyToAsync(stream, cancellationToken);
            }
            
            var updatedUser = new ApplicationUser()
            {
                FullName = request.FullName!,
                CreatedAt = DateTime.UtcNow,
                DeletedAt = null,
                PictureUrl = fileName,
                CountryId = (int)request.CountryId!
            };
            
            context.Users.Update(updatedUser);
            await context.SaveChangesAsync(cancellationToken);
            return updatedUser;
        }
    }
}
