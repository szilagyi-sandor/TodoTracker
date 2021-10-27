using System;
using Domain;
using Application.Tests;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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