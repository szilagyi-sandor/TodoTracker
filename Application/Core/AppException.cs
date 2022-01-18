namespace Application.Core
{
  // CHECKED 1.0
  public class AppException
  {
    public string? Message { get; set; }
    public string? Details { get; set; }
    public int? StatusCode { get; set; }
    public int? ErrorTypeId { get; set; }

    public AppException(int? statusCode, int? errorTypeId, string? message, string? details = null)
    {
      Message = message;
      Details = details;
      StatusCode = statusCode;
      ErrorTypeId = errorTypeId;
    }
  }
}
