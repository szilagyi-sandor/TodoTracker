namespace API.Middleware;

public class ExceptionMiddleware
{
  private readonly IHostEnvironment _env;
  private readonly RequestDelegate _next;
  private readonly ILogger<ExceptionMiddleware> _logger;
  public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
  {
    _env = env;
    _next = next;
    _logger = logger;

  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, ex.Message);
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

      var response = _env.IsDevelopment()
       ? new AppException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
       : new AppException(context.Response.StatusCode, "Server Error.", ex.StackTrace?.ToString());

      var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

      var json = JsonSerializer.Serialize(response, options);

      await context.Response.WriteAsync(json);
    }
  }
}
