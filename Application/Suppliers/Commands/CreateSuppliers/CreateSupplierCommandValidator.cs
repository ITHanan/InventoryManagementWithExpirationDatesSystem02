using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Commands.CreateSuppliers
{
    public class CreateSupplierCommandValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            RuleFor(x => x.SupplierDto.SupplierName)
                   .NotEmpty().WithMessage("Supplier name is required.")
                   .MaximumLength(100).WithMessage("Supplier name must not exceed 100 characters.");

            RuleFor(x => x.SupplierDto.ContactPerson)
                .MaximumLength(50).WithMessage("Contact person name must not exceed 50 characters.")
                .When(x => !string.IsNullOrEmpty(x.SupplierDto.ContactPerson));

            RuleFor(x => x.SupplierDto.PhoneNumber)
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Phone number must be a valid international number.")
                .When(x => !string.IsNullOrEmpty(x.SupplierDto.PhoneNumber));
        }

    }
}
