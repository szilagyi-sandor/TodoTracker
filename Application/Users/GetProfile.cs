

namespace Application.Users
{
  // CHECKED 1.0
  public class GetProfile
  {
    // TODO: Set empty classes like this everywhere
    public class Query : IRequest<Result<ProfileDto>> { }

    public class Handler : IRequestHandler<Query, Result<ProfileDto>>
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

      public async Task<Result<ProfileDto>> Handle(Query request, CancellationToken cancellationToken)
      {
        var userEmail = _userAccessor.GetUserEmail();

        var user = await _userManager.FindByEmailAsync(userEmail);

        if (user == null)
          return Result<ProfileDto>.Fail(404);

        var profile = _mapper.Map<ProfileDto>(user);

        return Result<ProfileDto>.Success(profile);
      }
    }
  }
}


