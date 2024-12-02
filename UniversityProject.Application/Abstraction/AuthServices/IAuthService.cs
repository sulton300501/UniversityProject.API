using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.Abstraction.AuthServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(ApplicationUser user);
    }
}
