namespace Application.Dtos.Account
{
  // CHECKED 1.0
  public class EditEmailRequest
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
  }
}