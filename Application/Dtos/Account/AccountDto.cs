namespace Application.Dtos.Account
{
  // CHECKED 1.0
  public class AccountDto
  {
    public int Id { get; set; }
    public int Status { get; set; }
    public string Token { get; set; } = "";
    public string Email { get; set; } = "";
    public string DisplayName { get; set; } = "";
  }
}
