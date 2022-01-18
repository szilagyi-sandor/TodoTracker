

namespace API.Security.InvalidUserRestriction
{
  // CHECKED 1.0
  public class InvalidUserRestrictionHandler : AuthorizationHandler<InvalidUserRestrictionRequirement>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public InvalidUserRestrictionHandler(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    // Protects the endpoints from deleted users with a valid token.
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
      InvalidUserRestrictionRequirement requirement)
    {
      var email = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Email);
      var userManager = _httpContextAccessor.HttpContext?.RequestServices.GetRequiredService<UserManager<AppUser>>();

      if (email == null || userManager == null)
      {
        context.Fail();

        return;
      }

      var user = await userManager.FindByEmailAsync(email);

      if (user == null)
      {
        context.Fail();

        return;
      }

      context.Succeed(requirement);
    }
  }
}
