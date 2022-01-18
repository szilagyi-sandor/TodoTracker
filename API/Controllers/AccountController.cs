namespace API.Controllers
{
  // CHECKED 1.0
  [ApiController]
  [Route("api/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly TokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
      TokenService tokenService, IMapper mapper)
    {
      _mapper = mapper;
      _userManager = userManager;
      _tokenService = tokenService;
      _signInManager = signInManager;
    }

    [HttpGet]
    public async Task<ActionResult<AccountDto>> GetCurrentAccount()
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

      if (user == null)
        return Unauthorized();

      var accountDto = _mapper.Map<AccountDto>(user);
      accountDto.Token = await _tokenService.CreateToken(user);

      return accountDto;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<AccountDto>> Login(LoginRequestDto request)
    {
      var user = await _userManager.FindByEmailAsync(request.Email);

      if (user == null)
        return Unauthorized();

      var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

      if (!result.Succeeded)
        return Unauthorized();

      var accountDto = _mapper.Map<AccountDto>(user);
      accountDto.Token = await _tokenService.CreateToken(user);

      return accountDto;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<AccountDto>> Register(RegisterRequestDto request)
    {
      var user = _mapper.Map<AppUser>(request);

      var result = await _userManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
      {
        foreach (var error in result.Errors)
        {
          if (error.Code != "DuplicateUserName")
          {
            ModelState.AddModelError(error.Code, error.Description);
          }
        }

        return ValidationProblem();
      }

      var accountDto = _mapper.Map<AccountDto>(user);
      accountDto.Token = await _tokenService.CreateToken(user);

      return accountDto;
    }

    [HttpPut("/email")]
    public async Task<ActionResult<AccountDto>> EditEmail(EditEmailRequest request)
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

      if (user == null)
        return NotFound();

      // TODO: If Email validation will be required use ChangeEmailAsync
      // instead of SetEmailAsync.
      await _userManager.SetEmailAsync(user, request.Email);
      await _userManager.SetUserNameAsync(user, request.Email);

      var accountDto = _mapper.Map<AccountDto>(user);
      accountDto.Token = await _tokenService.CreateToken(user);

      return accountDto;
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteMyself()
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

      if (user == null)
        return Unauthorized();

      var result = await _userManager.DeleteAsync(user);

      if (!result.Succeeded)
        return StatusCode(500, "Problem occured while deleting the User.");

      return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    // Deleted Users with valid token will still able to call simply protected endpoints. 
    // To prevent endpoints from this use the InvalidUserRestriction policy.
    public async Task<IActionResult> DeleteUser(int id)
    {
      var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == id);

      if (user == null)
        return NotFound();

      var result = await _userManager.DeleteAsync(user);

      if (!result.Succeeded)
        return StatusCode(500, "Problem occured while deleting the User.");

      return Ok();
    }
  }
}
