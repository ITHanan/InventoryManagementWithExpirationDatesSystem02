using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Commands.DeletStock
{
    public class DeleteStockCommand : IRequest<OperationResult<bool>>
    {
        public int StockId { get; set; }

        public DeleteStockCommand(int stockId)
        {
            StockId = stockId;
        }

    }
}
