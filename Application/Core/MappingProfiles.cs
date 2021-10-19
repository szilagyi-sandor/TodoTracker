using Domain;
using AutoMapper;

namespace Application.Core
{
  public class MappingProfiles : Profile
  {
    public MappingProfiles()
    {
      CreateMap<Test, Test>();
    }
  }
}