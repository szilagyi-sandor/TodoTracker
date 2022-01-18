namespace Domain.Account
{
  // CHECKED 1.0
  public class AppUser : IdentityUser<int>
  {
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string DisplayName { get; set; } = "";
  }
}