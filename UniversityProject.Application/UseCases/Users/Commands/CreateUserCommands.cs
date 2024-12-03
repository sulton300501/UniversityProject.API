using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Users.Commands
{
    public class CreateUserCommands : IRequest<ApplicationUser>
    {
        public string FullName { get; set; } = String.Empty;
        public string? PhoneNumber { get; set; }
        public string Password { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public IFormFile? Picture { get; set; }
        public int CountryId { get; set; }
    }
}
