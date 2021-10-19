using Domain;
using MediatR;
using AutoMapper;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Tests
{
  public class Edit
  {
    public class Command : IRequest
    {
      public Test Test { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
      private readonly IMapper _mapper;
      private readonly DataContext _context;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {
        var test = await _context.Tests.FindAsync(request.Test.Id);

        _mapper.Map(request.Test, test);

        await _context.SaveChangesAsync();

        return Unit.Value;
      }
    }
  }
}