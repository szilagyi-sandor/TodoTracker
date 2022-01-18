

namespace API.Security.InvalidStatusRestriction
{
  // CHECKED 1.0
  public class InvalidStatusRestrictionHandler : AuthorizationHandler<InvalidStatusRestrictionRequirement>
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public InvalidStatusRestrictionHandler(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    // Protects the endpoints from not approved users.
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InvalidStatusRestrictionRequirement requirement)
    {
      var status = _httpContextAccessor.HttpContext?.User.FindFirstValue(CustomClaimTypes.UserStatus.ToString());

      if (status == null || Int32.Parse(status) != (int)UserStatusTypes.approved)
      {
        context.Fail();

        return Task.CompletedTask;
      }

      context.Succeed(requirement);

      return Task.CompletedTask;
    }
  }
}
