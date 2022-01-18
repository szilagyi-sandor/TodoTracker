namespace Application.Tests
{
  public class Edit
  {
    public class Command : IRequest<Result<Unit>>
    {
      public Test Test { get; set; } = new Test();
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Test).SetValidator(new TestValidator());
      }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>?>
    {
      private readonly IMapper _mapper;
      private readonly DataContext _context;
      public Handler(DataContext context, IMapper mapper)
      {
        _mapper = mapper;
        _context = context;
      }

      public async Task<Result<Unit>?> Handle(Command request, CancellationToken cancellationToken)
      {
        var test = await _context.Tests.FindAsync(request.Test.Id);

        if (test == null) return null;

        _mapper.Map(request.Test, test);

        var result = await _context.SaveChangesAsync() > 0;

        if (!result)
          return Result<Unit>.Fail("Failed to update the test.");

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}
