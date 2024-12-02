using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Handlers
{
    public class DeleteUserCommandHandler(DataContext context)
        : IRequestHandler<DeleteUserCommand, ApplicationUser>
    {
        public async Task<ApplicationUser> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .FirstOrDefaultAsync(x=>x.Id==request.Id, cancellationToken);
            
            if (user == null)
                throw new Exception("Not found!");

            context.Users.Remove(user);
            await context.SaveChangesAsync(cancellationToken);
            return user;
        }
    }
}
