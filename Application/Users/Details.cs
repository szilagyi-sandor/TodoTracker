namespace Application.Users
{
  public class Details
  {
    public class Query : IRequest<Result<UserDto>>
    {
      public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<UserDto>>
    {
      private readonly IMapper _mapper;
      private readonly UserManager<AppUser> _userManager;

      public Handler(UserManager<AppUser> userManager, IMapper mapper)
      {
        _mapper = mapper;
        _userManager = userManager;
      }

      public async Task<Result<UserDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == request.Id);

        if (user == null)
          return Result<UserDto>.Fail(404);

        return Result<UserDto>.Success(_mapper.Map<UserDto>(user));
      }
    }
  }
}