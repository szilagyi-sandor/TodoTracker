using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tests
{
  public class Create
  {
    public class Command : IRequest
    {
      public Test Test { get; set; }
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
        _context.Tests.Add(request.Test);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}