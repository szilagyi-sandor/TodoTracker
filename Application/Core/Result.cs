namespace Application.Core
{
  // CHECKED 1.0
  public class Result<T>
  {
    public T? Value { get; set; }
    public bool isSuccess { get; set; }
    public string? ErrorMessage { get; set; }
    public int? StatusCode { get; set; } = null;
    public int? ErrorTypeId { get; set; }

    public static Result<T> Success(T value) => new Result<T> { isSuccess = true, Value = value };

    public static Result<T> Fail(int statusCode, string errorText, int errorTypeId) => new Result<T>
    {
      isSuccess = false,
      StatusCode = statusCode,
      ErrorMessage = errorText,
      ErrorTypeId = errorTypeId
    };

    public static Result<T> Fail(int statusCode, string errorText) => new Result<T>
    {
      isSuccess = false,
      StatusCode = statusCode,
      ErrorMessage = errorText
    };

    public static Result<T> Fail(int statusCode) => new Result<T>
    {
      isSuccess = false,
      StatusCode = statusCode,
    };

    public static Result<T> Fail(string errorText) => new Result<T>
    {
      isSuccess = false,
      ErrorMessage = errorText
    };

    public static Result<T> Fail() => new Result<T>
    {
      isSuccess = false,
    };
  }
}