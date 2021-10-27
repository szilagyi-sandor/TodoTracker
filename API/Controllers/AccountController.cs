using Domain;
using API.Dtos;
using API.Services;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AccountController : ControllerBase
  {
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly TokenService _tokenService;
    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
    {
      _userManager = userManager;
      _tokenService = tokenService;
      _signInManager = signInManager;
    }

    [HttpGet("me")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
      var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

      // TODO: Automapper
      return new UserDto
      {
        Id = user.Id,
        DisplayName = user.DisplayName,
        Token = _tokenService.CreateToken(user),
        Username = user.UserName
      };
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginRequestDto request)
    {
      var user = await _userManager.FindByEmailAsync(request.Email);

      if (user == null)
        return Unauthorized();

      var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

      if (!result.Succeeded)
        return Unauthorized();

      // TODO: AutoMapper
      // TODO: Token handling
      return new UserDto
      {
        Id = user.Id,
        DisplayName = user.DisplayName,
        Username = user.UserName,
        Token = _tokenService.CreateToken(user)
      };
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterRequestDto request)
    {
      if (await _userManager.Users.AnyAsync(x => x.Email == request.Email))
      {
        ModelState.AddModelError("email", "Already taken.");
        return ValidationProblem();
      }

      if (await _userManager.Users.AnyAsync(x => x.UserName == request.Username))
      {
        ModelState.AddModelError("username", "Already taken.");
        return ValidationProblem();
      }

      // TODO: Automapper
      var user = new AppUser
      {
        DisplayName = request.DisplayName,
        Email = request.Email,
        UserName = request.Username
      };

      var result = await _userManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
        return BadRequest("Problem registering user.");

      // TODO: Automapper
      return new UserDto
      {
        Id = user.Id,
        DisplayName = user.DisplayName,
        Token = _tokenService.CreateToken(user),
        Username = user.UserName
      };
    }
  }
}