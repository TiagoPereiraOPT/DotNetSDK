﻿using FluentValidation;

namespace JudoPayDotNet.Models.Validations
{
	internal class VoidsValidator : AbstractValidator<VoidModel>
    {
        public VoidsValidator()
        {
            RuleFor(model => model.ReceiptId)
                .NotEmpty().WithMessage("You must supply the receipt id of pre authorization transaction");

            RuleFor(model => model.Amount)
                .NotEmpty().WithMessage("You must supply the amount to void")
                .GreaterThan(0.00M).WithMessage("Sorry, this amount is not valid.");

            RuleFor(model => model.YourPaymentReference)
                .NotEmpty().WithMessage("You must supply your payment reference");
        }
    }
}
