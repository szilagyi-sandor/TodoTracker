namespace API.Extensions
{
  // CHECKED 1.0
  public static class IdentityServiceExtensions
  {
    public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
    {
      services
        .AddIdentityCore<AppUser>(opt =>
        {
          opt.User.RequireUniqueEmail = true;
        })
        .AddRoles<Role>()
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

      services.AddSingleton<IAuthorizationHandler, InvalidUserRestrictionHandler>();
      services.AddSingleton<IAuthorizationHandler, InvalidStatusRestrictionHandler>();

      services.AddAuthorization(options =>
      {
        options.AddPolicy("InvalidUserRestriction", policy => policy.AddRequirements(new InvalidUserRestrictionRequirement()));
        options.AddPolicy("InvalidStatusRestriction", policy => policy.AddRequirements(new InvalidStatusRestrictionRequirement()));
      });

      services.AddScoped<TokenService>();

      return services;
    }
  }
}
