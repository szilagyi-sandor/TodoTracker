namespace Application.Core
{
  // CHECKED 1.0
  public class PageHelper
  {
    public int Skip { get; set; }
    public int Take { get; set; }
    public int TotalPages { get; set; }
    public int Page { get; set; }

    public static PageHelper Create(PagedRequest request, int totalCount)
    {
      return new PageHelper
      {
        Take = request.PageSize,
        Page = request.PageNumber,
        Skip = (request.PageNumber - 1) * request.PageSize,
        TotalPages = (int)Math.Ceiling(totalCount / (double)request.PageSize)
      };
    }
  }
}