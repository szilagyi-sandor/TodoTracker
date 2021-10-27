using System;
using Domain;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;

namespace API.Services
{
  public class TokenService
  {
    public IConfiguration _config { get; set; }
    public TokenService(IConfiguration config)
    {
      _config = config;
    }

    public string CreateToken(AppUser user)
    {
      var claims = new List<Claim>
        {
          new Claim(ClaimTypes.Name, user.UserName),
          new Claim(ClaimTypes.NameIdentifier, user.Id),
          new Claim(ClaimTypes.Email, user.Email),
        };

      // TODO: secret storage
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      // TODO: Token refresh modifications
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(claims),
        Expires = DateTime.Now.AddDays(7),
        SigningCredentials = creds
      };

      var tokenHandler = new JwtSecurityTokenHandler();

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }
  }
}