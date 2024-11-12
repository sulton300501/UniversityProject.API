using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.Abstraction.AuthServices
{
    public interface IAuthService
    {
        public Task<string> GenerateToken(ApplicationUser user);
    }
}
