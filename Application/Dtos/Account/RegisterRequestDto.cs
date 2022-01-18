

namespace Application.Dtos.Account
{
  // CHECKED 1.0
  public class RegisterRequestDto
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
    [Required]
    [RegularExpression("(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{4,8}$", ErrorMessage = "Password must be complex.")]
    public string Password { get; set; } = "";
    public string DisplayName { get; set; } = "";
  }
}

