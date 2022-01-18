namespace Application.Dtos.Users
{
  // CHECKED 1.0
  public class UserListDto
  {
    public int Id { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Email { get; set; } = "";
    public string DisplayName { get; set; } = "";
  }
}