using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.ProductPrice)
                .NotEmpty();
        }
    }
}
