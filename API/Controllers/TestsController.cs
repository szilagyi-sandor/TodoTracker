using System;
using Domain;
using Persistence;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  public class TestsController : BaseApiController
  {
    private readonly DataContext _context;
    public TestsController(DataContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Test>>> GetTests()
    {
      return await _context.Tests.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Test>> GetTest(Guid id)
    {
      return await _context.Tests.FindAsync(id);
    }
  }
}