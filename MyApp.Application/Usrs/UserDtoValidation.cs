using FluentValidation;
using MyApp.Domain.Users;

namespace MyApp.Application.Usrs;

public class UserDtoValidation : AbstractValidator<UserMapperProfile>
{

    public UserDtoValidation()
    {
        RuleFor(u => u.Name).NotEmpty().NotNull()
            .WithMessage("Name is requaird");
        RuleFor(u=>u.Email).NotEmpty().WithMessage("Email Is required ");
        RuleFor(u => u.Name).MaximumLength(20).WithMessage("the name must be maximum 20 characrter .");

    }



}

