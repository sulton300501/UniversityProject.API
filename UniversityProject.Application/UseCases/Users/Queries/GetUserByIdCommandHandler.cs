using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Queries
{
    public class GetUserByIdCommandHandler(DataContext context)
        : IRequestHandler<GetUserByIdCommand, ApplicationUser>
    {
        public Task<ApplicationUser> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = context.Users
                .Include(a => a.Report)
                .Include(a => a.Country)
                .FirstOrDefault(a=> a.Id == request.Id);
            
            if (user == null)
                throw new Exception("Not found!");

            return Task.FromResult(user);
        }
    }
}
