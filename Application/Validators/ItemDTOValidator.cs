using ApplicationLayer.ACommen.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Validators
{
    internal class ItemDTOValidator : AbstractValidator<ItemDto>
    {
        public ItemDTOValidator()
        {
            RuleFor(x => x.ItemName)
                .NotEmpty().WithMessage("Item name is required.")
                .MaximumLength(50).WithMessage("Item name must not exceed 50 characters.");

            RuleFor(x => x.UnitPrice)
                .NotNull().WithMessage("Unit price is required.")
                .GreaterThan(0).WithMessage("Unit price must be greater than 0.");

            RuleFor(x => x.Category)
                .MaximumLength(30).WithMessage("Category must not exceed 30 characters.")
                .When(x => !string.IsNullOrEmpty(x.Category));
        }
    }
    
    
}
