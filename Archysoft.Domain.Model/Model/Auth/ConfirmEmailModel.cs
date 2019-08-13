using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Archysoft.Domain.Model.Model.Auth
{
    public class ConfirmEmailModel
    {
        public string UserId { get; set; }
        public string Code { get; set; }
    }

    public class ConfirmEmailModelValidator : AbstractValidator<ConfirmEmailModel>
    {
        public ConfirmEmailModelValidator()
        {
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.Code).NotNull();
        }
    }
}
