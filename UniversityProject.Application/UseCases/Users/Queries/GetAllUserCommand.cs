using MediatR;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Users.Queries
{
    public class GetAllUserCommand 
        : IRequest<List<ApplicationUser>> { }
}
