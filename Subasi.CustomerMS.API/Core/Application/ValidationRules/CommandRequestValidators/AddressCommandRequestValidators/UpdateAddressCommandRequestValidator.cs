﻿using FluentValidation;
using Subasi.CustomerMS.API.Core.Application.Features.CQRS.Commands.AddressCommands;

namespace Subasi.CustomerMS.API.Core.Application.ValidationRules.CommandRequestValidators.AddressCommandRequestValidators
{
    public class UpdateAddressCommandRequestValidator : AbstractValidator<UpdateAddressCommandRequest>
    {
        public UpdateAddressCommandRequestValidator()
        {
            RuleFor(x => x.AddressLine)
                .NotNull()
                .NotEmpty().WithMessage("Address line required.")
                .MinimumLength(5).WithMessage("Address line must not be less than 5 characters.")
                .MaximumLength(100).WithMessage("Address line must not exceed 100 characters.");

            RuleFor(x => x.District)
                .NotNull()
                .NotEmpty().WithMessage("District required.")
                .MinimumLength(2).WithMessage("District must not be less than 2 characters.")
                .MaximumLength(100).WithMessage("District must not exceed 100 characters.");

            RuleFor(x => x.Province)
                .NotNull()
                .NotEmpty().WithMessage("Province required.")
                .MinimumLength(2).WithMessage("Province must not be less than 2 characters.")
                .MaximumLength(100).WithMessage("Province must not exceed 100 characters.");
        }
    }
}
