using System;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tests
{
  public class Delete
  {
    public class Command : IRequest
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var test = await _context.Tests.FindAsync(request.Id);

        _context.Remove(test);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}