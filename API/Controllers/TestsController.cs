using System;
using Domain;
using Application.Tests;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
  public class TestsController : BaseApiController
  {
    [HttpGet]
    public async Task<ActionResult<List<Test>>> GetTests()
    {
      return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Test>> GetTest(Guid id)
    {
      return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateTest(Test test)
    {
      await Mediator.Send(new Create.Command { Test = test });

      return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> EditTest(Guid id, Test test)
    {
      test.Id = id;

      await Mediator.Send(new Edit.Command { Test = test });

      return Ok();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTest(Guid id)
    {
      await Mediator.Send(new Delete.Command { Id = id });

      return Ok();
    }
  }
}