using Domain;
using FluentValidation;

namespace Application.Tests
{
  public class TestValidator : AbstractValidator<Test>
  {
    public TestValidator()
    {
      RuleFor(x => x.Title).NotEmpty();
      RuleFor(x => x.Date).NotEmpty();
    }
  }
}