namespace Application.Core;

// TODO: Refactor result handling.
public class Result<T>
{
  public T? Value { get; set; }
  public bool isSuccess { get; set; }
  public string Error { get; set; } = "";

  public static Result<T> Success(T? value) => new Result<T> { isSuccess = true, Value = value };
  public static Result<T> Fail(string error) => new Result<T> { isSuccess = false, Error = error };
}
