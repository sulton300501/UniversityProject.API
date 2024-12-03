using MediatR;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Users.Commands
{
    public class DeleteUserCommand : IRequest<ApplicationUser>
    {
        public int Id { get; set; }
    }
}
