using ApplicationLayer.ACommen.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Validators
{
    internal class StockDTOValidator : AbstractValidator<StockDTO>
    {
        public StockDTOValidator()
        {
            RuleFor(stock => stock.Quantity).GreaterThan(0)
                .WithMessage("Stock quantity must be greater than zero.");
            RuleFor(stock => stock.ItemId).NotEmpty()
                .WithMessage("Item ID is required.");

            RuleFor(x => x.ExpiryDate)
                .GreaterThan(DateTime.UtcNow).WithMessage("Expiry date must be in the future.");
        }

        private bool BeAValidDate(DateOnly expiryDate)
        {
            // Example of date validation, you could add range or format checks if needed
            return expiryDate != null && expiryDate >= DateOnly.FromDateTime(DateTime.Today);
        }
    }
    
    
}
