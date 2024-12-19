using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Film_PProject.Infrastructure.Settings;
using Films_PProject.Application.Interfaces;
using Films_PProject.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Cinema.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSetting _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSetting> jwtSettingsOptions)
    {
        _jwtSettings = jwtSettingsOptions.Value;
    }
    public string GenerateToken(User entity)
    {
        var siginingCredential = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            SecurityAlgorithms.HmacSha256);
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, entity.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role,entity.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier, entity.Id.ToString())
        };
        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpireInMinutes),
            claims: claims,
            signingCredentials: siginingCredential);
        
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}