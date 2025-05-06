using DomainLayer.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ApplicationLayer.Stocks.Commands.CreateStocks
{
    public class AddStockCommandValidator : AbstractValidator<AddStockCommand>
    {
        public AddStockCommandValidator()
        {
            RuleFor(x => x.StockDto.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            RuleFor(x => x.StockDto.ItemId).NotEmpty().WithMessage("Item ID is required.");
            RuleFor(x => x.StockDto.ExpiryDate).GreaterThan(DateTime.UtcNow).WithMessage("Expiry date must be in the future.");

        }



    }
}
