using MediatR;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Users.Commands;

public class GetUserByIdCommand : IRequest<ApplicationUser>
{
    public int Id { get; set; }
}