// TODO: Use new namespace rule, when the coloring works fine.
using Application.Users;

namespace API.Controllers
{
  // CHECKED 1.0
  public class UsersController : BaseApiController
  {
    [HttpGet("profile")]
    public async Task<IActionResult> GetProfile()
    {
      return HandleResult(await Mediator.Send(new GetProfile.Query()));
    }

    [HttpPut("profile")]
    public async Task<IActionResult> EditProfile(EditProfile.Command command)
    {
      return HandleResult(await Mediator.Send(command));
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUsers([FromQuery] UserListRequest request)
    {
      return HandleResult(await Mediator.Send(new List.Query { param = request }));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUser(int id)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }

    [HttpPut("status/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditUserStatus([FromRoute] int id, [FromBody] EditUserStatusRequestBody requestBody)
    {
      return HandleResult(await Mediator.Send(new EditStatus.Command { Id = id, Status = requestBody.Status }));
    }
  }
}
