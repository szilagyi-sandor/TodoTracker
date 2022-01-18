namespace Application.Dtos._Common
{
  // CHECKED 1.0
  public class PagedItems<T>
  {
    public List<T> Items { get; set; } = new List<T>();
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }

    public PagedItems() { }

    public PagedItems(List<T> items, PageHelper helper)
    {
      Items = items;
      Page = helper.Page;
      PageSize = helper.Take;
      TotalPages = helper.TotalPages;
    }
  }
}