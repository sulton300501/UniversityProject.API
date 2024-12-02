using MediatR;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Domain.Entities.DTOs;

namespace UniversityProject.Application.UseCases.Users.Commands;

public class GetUserByIdCommand : IRequest<UserDTO>
{
    public int Id { get; set; }
}