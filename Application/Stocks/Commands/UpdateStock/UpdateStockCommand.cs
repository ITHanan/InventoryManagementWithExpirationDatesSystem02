using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;

namespace ApplicationLayer.Stocks.Commands
{
    public class UpdateStockCommand : IRequest<OperationResult<StockDTO>>
    {
        public StockDTO UpdatedStockDto { get; set; }

        public UpdateStockCommand(StockDTO updatedStockDto)
        {
            UpdatedStockDto = updatedStockDto;
        }
    }
}
