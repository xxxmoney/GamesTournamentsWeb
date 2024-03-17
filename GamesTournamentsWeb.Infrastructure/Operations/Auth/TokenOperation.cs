using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GamesTournamentsWeb.Common.Enums.Account;
using GamesTournamentsWeb.Infrastructure.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GamesTournamentsWeb.Infrastructure.Operations.Auth;

public interface ITokenOperation : IOperation
{
    string CreateToken(int accountId, int roleId);
}

public class TokenOperation(IOptions<AppSettings> appSettings, TimeProvider timeProvider) : ITokenOperation
{
    public string CreateToken(int accountId, int roleId)
    {
        var claims = new List<Claim>
        {
            new (ClaimTypes.Name, accountId.ToString()),
        };
        
        // Add roles
        foreach (RoleEnum roleEnumValue in Enum.GetValues(typeof(RoleEnum)))
        {
            // Check whether int value of roleEnumValue is less than or equal
            // This is because role with higher values has permission of those with lower values
            if ((int)roleEnumValue <= roleId)
            {
                string roleName = Enum.GetName(typeof(RoleEnum), roleEnumValue);
                claims.Add(new Claim(ClaimTypes.Role, roleName ?? throw new Exception("Role name is null")));
            }
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(appSettings.Value.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = timeProvider.GetUtcNow().Add(Constants.TokenExpiration).DateTime,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }    
}