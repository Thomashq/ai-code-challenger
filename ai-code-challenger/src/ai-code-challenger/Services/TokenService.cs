using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ai_code_challenger.common;
using ai_code_challenger.common.Model;
using ai_code_challenger.common.Utility;
using Microsoft.IdentityModel.Tokens;

namespace ai_code_challenger.Services;

public static class TokenService
{
    public static string GenerateToken(Account account)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]{
                new Claim(ClaimTypes.Name, account.Login.ToString()),
                new Claim(ClaimTypes.Role, account.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

