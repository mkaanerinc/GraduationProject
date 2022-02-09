using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class InsuredPersonRelationshipValidator : AbstractValidator<InsuredPersonRelationshipDto>
    {
        public InsuredPersonRelationshipValidator()
        {
            RuleFor(i => i.InsuredPersonRelationshipName)
                .NotEmpty()
                .MaximumLength(10);
        }
    }
}
