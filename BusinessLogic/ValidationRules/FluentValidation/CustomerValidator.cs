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
    public class CustomerValidator : AbstractValidator<CustomerDto>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CustomerFirstName)
                .NotEmpty()
                .Length(2,50);

            RuleFor(c => c.CustomerLastName)
                .NotEmpty()
                .Length(2, 50);

            RuleFor(c => c.CustomerIdentityNo)
                .NotEmpty()
                .Length(11);


            RuleFor(c => c.CustomerBirthdate)
                .NotEmpty()
                .Must(CheckCustomerAge).WithMessage("Sigorta ettiren 18 yaşından büyük olmalıdır.");

            RuleFor(c => c.CustomerEmail)
                .NotEmpty()
                .MaximumLength(50)
                .Must(IsEmailValid).WithMessage("Email formatı geçersiz.");

            RuleFor(c => c.CustomerGSM)
                .NotEmpty()
                .Length(10);

            RuleFor(c => c.CustomerCity)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(c => c.CustomerAddress)
                .NotEmpty()
                .MaximumLength(255);

        }

        private bool IsEmailValid(string arg)
        {
            if (!MailAddress.TryCreate(arg, out var email))
                return false;
            return true;

        }

        private bool CheckCustomerAge(DateTime arg)
        {
            var result = DateTime.Now.Year - arg.Year;

            if(result < 18)
            {
                return false;
            }
            
            return true;
        }
    }
}
