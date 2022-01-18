

namespace Application.Dtos.Users
{
  // CHECKED 1.0
  public class UserListRequest : PagedRequest
  {
    public int? OrderBy { get; set; }
    public string? Search { get; set; }
    public List<int>? Statuses { get; set; }
    public DateTime? CreatedToDate { get; set; }
    public DateTime? CreatedFromDate { get; set; }
  }
}