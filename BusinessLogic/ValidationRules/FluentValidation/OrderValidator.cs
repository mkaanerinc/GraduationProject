using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator()
        {
            RuleFor(o => o.CustomerId)
                .NotEmpty();

            RuleFor(o => o.InstallmentOptionId)
                .NotEmpty();

            RuleFor(o => o.PaymentMethodId)
                .NotEmpty();

            RuleFor(o => o.ProductId)
                .NotEmpty();

            RuleFor(o => o.OrderPrice)
                .NotEmpty();

            RuleFor(o => o.OrderStatus)
                .NotEmpty();
        }
    }
}
