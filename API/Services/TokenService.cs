namespace API.Services
{
  // CHECKED 1.0
  public class TokenService
  {
    private readonly IConfiguration _config;
    private readonly UserManager<AppUser> _userManager;

    public TokenService(IConfiguration config, UserManager<AppUser> userManager)
    {
      _config = config;
      _userManager = userManager;
    }

    public async Task<string> CreateToken(AppUser user)
    {
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(CustomClaimTypes.UserStatus.ToString(), user.Status.ToString()),
      };

      var roles = await _userManager.GetRolesAsync(user);

      foreach (var role in roles)
      {
        claims.Add(new Claim(ClaimTypes.Role, role));
      }

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
