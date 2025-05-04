using ApplicationLayer.Interfaces.IGenericIRepository;
using ApplicationLayer.Interfaces.Repositories;
using ApplicationLayer.Stocks.Commands.DeletStock;
using DomainLayer;
using DomainLayer.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Commands.DeleteStock
{
    public class DeleteStockCommandHandler : IRequestHandler<DeleteStockCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Stock> _repository;

        public DeleteStockCommandHandler(IGenericRepository<Stock> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteStockCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.StockId);
        }
    }
}
