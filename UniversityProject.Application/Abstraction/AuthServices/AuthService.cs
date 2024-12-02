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
    public class AuthService(IConfiguration config)
        : IAuthService
    {
        public async Task<string> GenerateToken(ApplicationUser user)
        {
            SymmetricSecurityKey security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jWtSettings:Secret"]!));
            SigningCredentials creditials = new SigningCredentials(security, SecurityAlgorithms.HmacSha256);
            int expirePeriod = int.Parse(config["JWtSettings:Expire"]!);


            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat , EpochTime.GetIntDate(DateTime.UtcNow).ToString(CultureInfo.InvariantCulture) , ClaimValueTypes.Integer64),
                new Claim("UserId" , user.Id.ToString()),        
                new Claim("UserName" , user.FullName),
                new Claim("Email" , user.Email!),
                new Claim("Role"  , user.Role),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: config["JwtSettings:ValidIssure"],
                audience: config["JwtSettings:ValidAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirePeriod),
                signingCredentials: creditials);

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));

        }
    }
}
