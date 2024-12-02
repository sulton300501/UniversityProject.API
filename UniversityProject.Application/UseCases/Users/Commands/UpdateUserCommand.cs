using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Users.Commands
{
    public class UpdateUserCommand : IRequest<ApplicationUser>
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        public IFormFile? Picture { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CountryId { get; set; }
    }
}
