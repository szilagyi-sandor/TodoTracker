namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
  private IMediator _mediator;

  protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

  // TODO: Check out better, especially notFound
  protected ActionResult HandleResult<T>(Result<T> result)
  {
    if (result == null)
      return NotFound();

    if (result.isSuccess && result.Value != null)
      return Ok(result.Value);

    if (result.isSuccess && result.Value == null)
      return NotFound();

    return BadRequest();
  }
}
