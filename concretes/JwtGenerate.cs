using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using interfaces;
using Microsoft.IdentityModel.Tokens;
using models.Database;
using models.Utils;

namespace concretes;

public class JwtGenerate : IJwtGenerate
{
    private readonly JwtConfig _config;

    public JwtGenerate(JwtConfig config)
    {
        _config = config;
    }
    
    public string CreateToken(Usuario usuario)
    {
        var claims = new List<Claim>
        {
            new Claim("username", usuario.Username),
            new Claim("id", usuario.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));

        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescription = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = credential
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescription);

        return tokenHandler.WriteToken(token);
    }
}