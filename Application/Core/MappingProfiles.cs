using Application.Users;

namespace Application.Core
{
  // CHECKED 1.0
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      // Account.

      CreateMap<AppUser, AccountDto>();

      CreateMap<RegisterRequestDto, AppUser>()
        .ForMember(u => u.UserName,
          r => r.MapFrom(r => r.Email))
        .ForMember(u => u.DisplayName,
          r => r.MapFrom(r =>
            string.IsNullOrWhiteSpace(r.DisplayName)
            ? ""
            : r.DisplayName))
        .AfterMap((_, u) =>
        {
          u.CreatedAt = DateTime.Now;
          u.Status = (int)UserStatusTypes.pending;
        });

      // Users.

      CreateMap<AppUser, UserDto>();

      CreateMap<AppUser, UserListDto>();

      CreateMap<AppUser, ProfileDto>();

      CreateMap<EditProfile.Command, AppUser>();

      // Test
      CreateMap<Test, Test>();
    }
  }
}

