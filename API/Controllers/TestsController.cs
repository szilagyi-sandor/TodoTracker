using Application.Tests;

namespace API.Controllers
{
  public class TestsController : BaseApiController
  {
    [HttpGet]
    public async Task<IActionResult> GetTests()
    {
      return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTest(Guid id)
    {
      return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("admin-secret")]
    public IActionResult GetAdminSecret()
    {
      return Ok(42);
    }

    [Authorize(Roles = "Admin")]
    [Authorize(Policy = "InvalidUserRestriction")]
    [HttpGet("policy-test")]
    public IActionResult GetPolicyTestValue()
    {
      return Ok(42);
    }

    [Authorize(Policy = "InvalidStatusRestriction")]
    [HttpGet("policy-test-2")]
    public IActionResult GetPolicyTestValue2()
    {
      return Ok(42);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTest(Test test)
    {
      return HandleResult(await Mediator.Send(new Create.Command { Test = test }));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditTest(Guid id, Test test)
    {
      test.Id = id;

      return HandleResult(await Mediator.Send(new Edit.Command { Test = test }));
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTest(Guid id)
    {
      return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
  }
}
