using FluentValidation;
using RpnInnovation.Application.Features.Account.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpnInnovation.Application.Validations
{
    public class AccountCreationRequestValidator : AbstractValidator<AccountCreationRequest>
    {
        public AccountCreationRequestValidator() 
        {
            RuleFor(t => t.FirstName)
                .NotEmpty().WithMessage("Firstname cannot be empty.")
                .NotNull()
                .MaximumLength(240);
            RuleFor(t => t.LastName)
               .NotEmpty().WithMessage("Firstname cannot be empty.")
               .NotNull()
               .MaximumLength(240);
            RuleFor(t => t.Email)
               .EmailAddress().WithMessage("Provide a valid email address.")
               .NotNull()
               .MaximumLength(250);
            RuleFor(t => t.Phone)
            .NotEmpty().WithMessage("Provide a phone number.")
            .NotNull()
            .MaximumLength(10);

        }
    }
}
