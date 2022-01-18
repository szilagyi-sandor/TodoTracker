namespace API.Controllers
{
  // CHECKED 1.0
  [ApiController]
  [Route("api/[controller]")]
  public class BaseApiController : ControllerBase
  {
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected ActionResult HandleResult<T>(Result<T> result)
    {
      if (result.isSuccess && result.Value != null)
        return Ok(result.Value);

      var err = new AppException(result.StatusCode, result.ErrorTypeId, result.ErrorMessage);

      if (!result.isSuccess)
      {
        switch (result.StatusCode)
        {
          case 404:
            return NotFound(err);

          case 500:
            return StatusCode(500, err);

          default:
            return BadRequest(err);
        }
      }

      return BadRequest(err);
    }
  }
}
