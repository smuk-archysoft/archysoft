using System;
using FluentValidation;

namespace Archysoft.Domain.Model.Model.Auth
{
    public class SignupModel
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }

    public class RegisterModelValidator : AbstractValidator<SignupModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Username).NotNull();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password)
                .Equal(x => x.PasswordConfirm)
                .When(x => !String.IsNullOrWhiteSpace(x.Password));
        }
    }
}
