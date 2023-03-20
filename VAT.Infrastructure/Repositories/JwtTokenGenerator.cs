using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VAT.Infrastructure.RepositoryInterfaces;

namespace VAT.Infrastructure.Repositories
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        public string GenerateToken(string UserId, string UserName, string Email)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super-Secret-Key")),
                SecurityAlgorithms.HmacSha256
                );
            var clams = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, UserId),
                new Claim(JwtRegisteredClaimNames.Email,Email),
            };

            var token = new JwtSecurityToken(
                issuer:"VAT-Web-API",
                expires: DateTime.Now.AddDays(1),
                claims:clams,
                signingCredentials:signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
