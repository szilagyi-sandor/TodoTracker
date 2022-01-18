namespace Application.Users
{
  // CHECKED 1.0
  public class List
  {
    public class Query : IRequest<Result<PagedItems<UserListDto>>>
    {
      public UserListRequest param { get; set; } = new UserListRequest();
    }

    public class Handler : IRequestHandler<Query, Result<PagedItems<UserListDto>>>
    {
      private readonly IMapper _mapper;
      private readonly UserManager<AppUser> _userManager;

      public Handler(UserManager<AppUser> userManager, IMapper mapper)
      {
        _mapper = mapper;
        _userManager = userManager;
      }

      public async Task<Result<PagedItems<UserListDto>>> Handle(Query request, CancellationToken cancellationToken)
      {
        var param = request.param;

        var query = _userManager.Users
          .ProjectTo<UserListDto>(_mapper.ConfigurationProvider)
          .AsQueryable();

        if (!string.IsNullOrEmpty(param.Search))
        {
          var search = param.Search.ToLower();

          query = query.Where(u =>
            u.Email.ToLower().Contains(search) ||
            u.DisplayName.ToLower().Contains(search));
        }

        if (param.CreatedFromDate != null)
        {
          query = query.Where(u => u.CreatedAt >= param.CreatedFromDate);
        }

        if (param.CreatedToDate != null)
        {
          query = query.Where(u => u.CreatedAt <= param.CreatedToDate);
        }

        if (param.Statuses != null)
        {
          query = query.Where(u => param.Statuses.Contains(u.Status));
        }

        var totalCount = await query.CountAsync();

        switch (param.OrderBy)
        {
          case (int)UserOrderByTypes.Email:
            query = query.OrderBy(u => u.Email);
            break;

          case (int)UserOrderByTypes.EmailDesc:
            query = query.OrderByDescending(u => u.Email);
            break;

          case (int)UserOrderByTypes.DisplayName:
            query = query.OrderBy(u => u.DisplayName);
            break;

          case (int)UserOrderByTypes.DisplayNameDesc:
            query = query.OrderByDescending(u => u.DisplayName);
            break;

          case (int)UserOrderByTypes.Status:
            query = query.OrderBy(u => u.Status);
            break;

          case (int)UserOrderByTypes.StatusDesc:
            query = query.OrderByDescending(u => u.Status);
            break;

          case (int)UserOrderByTypes.CreatedAtAscDesc:
            query = query.OrderByDescending(u => u.CreatedAt);
            break;

          default:
            query = query.OrderBy(u => u.CreatedAt);
            break;
        }

        var pageHelper = PageHelper.Create(param, totalCount);

        var users = await query
          .Skip(pageHelper.Skip)
          .Take(pageHelper.Take)
          .ToListAsync();

        return Result<PagedItems<UserListDto>>.Success(new PagedItems<UserListDto>(users, pageHelper));
      }
    }
  }
}


