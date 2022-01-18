namespace Application.Users
{
  // CHECKED 1.0
  public class EditProfile
  {
    public class Command : IRequest<Result<Unit>>
    {
      public string DisplayName { get; set; } = "";
    }

    public class CommandValidator : AbstractValidator<Command>
    {
      public CommandValidator()
      {
        RuleFor(x => x.DisplayName)
          .NotEmpty().WithMessage("Name must not be empty.");
      }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly IMapper _mapper;
      private readonly IUserAccessor _userAccessor;
      private readonly UserManager<AppUser> _userManager;

      public Handler(IUserAccessor userAccessor, UserManager<AppUser> userManager, IMapper mapper)
      {
        _mapper = mapper;
        _userManager = userManager;
        _userAccessor = userAccessor;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var userEmail = _userAccessor.GetUserEmail();

        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null)
          return Result<Unit>.Fail(404);

        _mapper.Map(request, user);

        await _userManager.UpdateAsync(user);

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}




