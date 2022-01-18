namespace Application.Users
{
  // CHECKED 1.0
  public class EditStatus
  {
    public class Command : IRequest<Result<Unit>>
    {
      public int Id { get; set; }
      public UserStatusTypes Status { get; set; }
    }

    public class CommandValidator : AbstractValidator<EditUserStatusRequestBody>
    {
      public CommandValidator()
      {
        RuleFor(x => x.Status)
          .NotEmpty().WithMessage("Status must not be empty.")
          .IsInEnum().WithMessage("Invalid Status");
      }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
      private readonly UserManager<AppUser> _userManager;

      public Handler(UserManager<AppUser> userManager)
      {
        _userManager = userManager;
      }

      public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
      {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
          return Result<Unit>.Fail(404);

        user.Status = (int)request.Status;

        await _userManager.UpdateAsync(user);

        return Result<Unit>.Success(Unit.Value);
      }
    }
  }
}