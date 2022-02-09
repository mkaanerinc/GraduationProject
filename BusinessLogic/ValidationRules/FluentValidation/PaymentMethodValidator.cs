using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class PaymentMethodValidator : AbstractValidator<PaymentMethodDto>
    {
        public PaymentMethodValidator()
        {
            RuleFor(p => p.PaymentMethodName)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
