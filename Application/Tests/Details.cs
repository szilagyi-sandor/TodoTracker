namespace Application.Tests
{
  public class Details
  {
    public class Query : IRequest<Result<Test>>
    {
      public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<Test>?>
    {
      private readonly DataContext _context;
      public Handler(DataContext context)
      {
        _context = context;
      }

      public async Task<Result<Test>?> Handle(Query request, CancellationToken cancellationToken)
      {
        var test = await _context.Tests.FindAsync(request.Id);

        if (test == null)
        {
          return Result<Test>.Fail(404);
        }

        return Result<Test>.Success(test);
      }
    }
  }
}
