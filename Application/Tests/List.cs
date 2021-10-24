using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Application.Core;

namespace Application.Tests
{
  public class List
  {
    public class Query : IRequest<Result<List<Test>>> { }

    public class Handler : IRequestHandler<Query, Result<List<Test>>>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<List<Test>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var tests = await _context.Tests.ToListAsync();

        return Result<List<Test>>.Success(tests);
      }
    }
  }
}