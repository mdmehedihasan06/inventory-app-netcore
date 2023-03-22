using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VAT.Infrastructure.RepositoryInterfaces.Authentication;
using VAT.Infrastructure.RepositoryInterfaces.Services;

namespace VAT.Infrastructure.Repositories.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IDateTimeProvider _iDateTimeProvider;
        private readonly JwtSettings _jwtSetting;

        public JwtTokenGenerator(IDateTimeProvider iDateTimeProvider, IOptions<JwtSettings> jwtOptions)
        {
            _iDateTimeProvider = iDateTimeProvider;
            _jwtSetting = jwtOptions.Value;
        }
        public string GenerateToken(string UserId, string UserName, string Email)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Secret)),
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
                issuer: _jwtSetting.Issuer,
                audience: _jwtSetting.Audience,
                expires: _iDateTimeProvider.UtcNow.AddMinutes(_jwtSetting.ExpireMinutes),
                claims: clams,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
