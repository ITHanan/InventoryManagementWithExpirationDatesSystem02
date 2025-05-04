using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;

namespace ApplicationLayer.Stocks.Queries
{
    public class GetStockByIdQuery : IRequest<OperationResult<StockDTO>>
    {
        public int StockId { get; }

        public GetStockByIdQuery(int stockId)
        {
            StockId = stockId;
        }
    }
}
