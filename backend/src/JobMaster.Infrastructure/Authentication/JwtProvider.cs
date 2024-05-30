using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobMaster.Application.Authentication.Interfaces;
using JobMaster.Domain.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JobMaster.Infrastructure.Authentication;

public sealed class JwtProvider(IOptions<JwtOptions> options)
    : IJwtProvider
{
    private readonly JwtOptions _options = options.Value;

    public string Generate(User user, out DateTime expirationDate)
    {
        var claims = new Claim[]
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.Value.ToString()),
            new(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new(JwtRegisteredClaimNames.Email, user.Email),
        };

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        expirationDate = DateTime.UtcNow.AddMinutes(_options.ExpirationInMinutes);
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: expirationDate,
            signingCredentials: signingCredentials
        );

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenValue;
    }
}