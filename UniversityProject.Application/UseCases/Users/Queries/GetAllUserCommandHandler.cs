using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Queries
{
    public class GetAllUserCommandHandler(DataContext context)
        : IRequestHandler<GetAllUserCommand, List<ApplicationUser>>
    {
        public async Task<List<ApplicationUser>> Handle(GetAllUserCommand request, CancellationToken cancellationToken)
        {
            return await context.Users
                .Include(a => a.Report)
                .Include(a => a.Country)
                .ToListAsync(cancellationToken);
        }
    }
}
