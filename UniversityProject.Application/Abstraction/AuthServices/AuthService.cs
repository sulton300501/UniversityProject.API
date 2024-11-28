using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.Abstraction.AuthServices
{
    public class AuthService : IAuthService
    {

        private readonly IConfiguration _config;

        public AuthService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<string> GenerateToken(ApplicationUser user)
        {
            SymmetricSecurityKey security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jWtSettings:Secret"]!));
            SigningCredentials creditials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(_config["JWtSettings:Expire"]!);


            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat , EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture) , ClaimValueTypes.Integer64),
                new Claim("UserId" , user.Id.ToString()),        
                new Claim(ClaimTypes.Name , user.Full_name),
                new Claim(ClaimTypes.Email , user.Email!),
                new Claim(ClaimTypes.Role  , user.Role),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _config["JwtSettings:ValidIssure"],
                audience: _config["JwtSettings:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: creditials);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
