using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Commands.CreateStocks
{
    public class AddStockCommand : IRequest<OperationResult<StockDTO>>
    {
        public StockDTO StockDto { get; }

        public AddStockCommand(StockDTO stockDto)
        {
            StockDto = stockDto;
        }
    }
}
