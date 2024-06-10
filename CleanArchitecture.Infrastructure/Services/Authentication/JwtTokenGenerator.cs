using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using CleanArchitecture.Application.Common.Interfaces.Authentication;
using CleanArchitecture.Application.Common.Interfaces.DateTimeProvider;
using Microsoft.Extensions.Options;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Services.Authentication;
public class JwtTokenGenerator : IJwtTokenGenerator
{

   private readonly IDateTimeProvider _dateTimeProvider;
   private readonly JwtSettingsOptions _options;
    public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettingsOptions> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _options = options.Value;
    }
    public string GenerateToken(User user)
    {
        var signingCredentials = new SigningCredentials
        (
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret)),
            SecurityAlgorithms.HmacSha256
        );

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName,user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString())
        };

        var securityToken = new JwtSecurityToken
        (
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: _dateTimeProvider.UtcNow.AddMinutes(_options.ExpiresMinutes),
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}