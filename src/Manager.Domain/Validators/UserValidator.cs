using FluentValidation;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Entity cannot be empty.");

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Name required")
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                .MinimumLength(2)
                .WithMessage("Name must be at least 2 characters.")
                .MaximumLength(80)
                .WithMessage("Password must be a maximum of 100 characters.");

            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password required.")
                .NotEmpty()
                .WithMessage("this fild cannot be empty.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters.")
                .MaximumLength(40)
                .WithMessage("Password must be a maximum of 40 characters.");

            RuleFor(x => x.Email)
              .NotNull()
              .WithMessage("E-mail required.")
              .NotEmpty()
              .WithMessage("E-mail cannot be empty.")
              .MinimumLength(10)
              .WithMessage("E-mail must be at least 10 characters.")
              .MaximumLength(180)
              .WithMessage("E-mail must be a maximum of 100 characters.")
              .Matches(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
              .WithMessage("E-mail invalid.");

        }
    }
}
