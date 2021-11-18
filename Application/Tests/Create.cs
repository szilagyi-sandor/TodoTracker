namespace Application.Tests;

public class Create
{
  public class Command : IRequest<Result<Unit>>
  {
    public Test Test { get; set; }
  }

  public class CommandValidator : AbstractValidator<Command>
  {
    public CommandValidator()
    {
      RuleFor(x => x.Test).SetValidator(new TestValidator());
    }
  }

  public class Handler : IRequestHandler<Command, Result<Unit>>
  {
    private readonly DataContext _context;
    public Handler(DataContext context)
    {
      _context = context;
    }

    public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
    {
      _context.Tests.Add(request.Test);

      var result = await _context.SaveChangesAsync() > 0;

      if (!result)
        return Result<Unit>.Fail("Failed to create the test.");

      return Result<Unit>.Success(Unit.Value);
    }
  }
}
