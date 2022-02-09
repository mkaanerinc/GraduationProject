using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class InstallmentOptionValidator : AbstractValidator<InstallmentOptionDto>
    {
        public InstallmentOptionValidator()
        {
            RuleFor(i => i.InstallmentOptionName)
                .NotEmpty()
                .Length(1, 5);
        }
    }
}
