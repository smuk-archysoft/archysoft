

using FluentValidation;

namespace Archysoft.Domain.Model.Model.Auth
{
    public class ForgotPasswordModel
    {
        public string Email { get; set; }
    }


    public class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordModelValidator()
        {
            RuleFor(model => model.Email).NotEmpty().EmailAddress();
        }
    }
}
