using Domain;
using System.Text;
using Persistence;
using API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Extensions
{
  public static class IdentityServiceExtensions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      // TODO: #1 UserRoles: Here AddIdentityCore says it does not add roles automatically.
      services
      .AddIdentityCore<AppUser>(opt =>
      {
        // TODO: things can be configured here
        // opt.Password.RequireNonAlphanumeric = false;
      })
      .AddEntityFrameworkStores<DataContext>()
      .AddSignInManager<SignInManager<AppUser>>();

      // TODO: secret storage
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));

      services
      .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(opt =>
      {

        opt.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = key,
          // TODO: Make it more bulletproof by configuring these
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddScoped<TokenService>();

      return services;
    }
  }
}