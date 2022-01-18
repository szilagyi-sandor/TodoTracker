

namespace Infrastructure.Security
{
  // CHECKED 1.0
  public class UserAccessor : IUserAccessor
  {
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccessor(IHttpContextAccessor httpContextAccessor)
    {
      _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserEmail()
    {
      if (_httpContextAccessor.HttpContext == null)
      {
        return "";
      }

      return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
    }
  }
}