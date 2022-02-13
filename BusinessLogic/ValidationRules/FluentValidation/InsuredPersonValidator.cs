using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.ValidationRules.FluentValidation
{
    public class InsuredPersonValidator : AbstractValidator<InsuredPersonDto>
    {
        public InsuredPersonValidator()
        {
            RuleFor(i => i.CustomerId)
                .NotEmpty();

            RuleFor(i => i.InsuredPersonRelationshipId)
                .NotEmpty();

            RuleFor(c => c.InsuredPersonFirstName)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(c => c.InsuredPersonLastName)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(c => c.InsuredPersonIdentityNo)
                .NotEmpty()
                .Length(11);

            RuleFor(c => c.InsuredPersonBirthdate)
                .NotEmpty()
                .Must(CheckInsuredPersonAge).When(c => c.InsuredPersonRelationshipId == 2).WithMessage("Sigortalı 18 yaşından büyük olmalıdır.");

            RuleFor(c => c.InsuredPersonBirthdate)
                .NotEmpty()
                .Must(CheckInsuredPersonAge).When(c => c.InsuredPersonRelationshipId == 1).WithMessage("Sigortalı 18 yaşından büyük olmalıdır.");

            RuleFor(c => c.InsuredPersonHeight)
                .NotEmpty();

            RuleFor(c => c.InsuredPersonWeight)
                .NotEmpty();

            RuleFor(c => c.InsuredPersonJob)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(c => c.InsuredPersonEmail)
                .NotEmpty()
                .MaximumLength(50)
                .Must(IsEmailValid).WithMessage("Email formatı geçersiz.");

            RuleFor(c => c.InsuredPersonGSM)
                .NotEmpty()
                .Length(10);

            RuleFor(c => c.InsuredPersonCity)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(c => c.InsuredPersonAddress)
                .NotEmpty()
                .MaximumLength(255);
        }

        private bool IsEmailValid(string arg)
        {
            if (!MailAddress.TryCreate(arg, out var email))
                return false;
            return true;

        }

        private bool CheckInsuredPersonAge(DateTime arg)
        {
            var result = DateTime.Now.Year - arg.Year;

            if (result < 18)
            {
                return false;
            }

            return true;
        }

    }
}
