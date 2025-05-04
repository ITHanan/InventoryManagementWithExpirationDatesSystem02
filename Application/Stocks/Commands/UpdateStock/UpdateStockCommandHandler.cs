using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.IGenericIRepository;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Commands
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, OperationResult<StockDTO>>
    {
        private readonly IGenericRepository<Stock> _repository;
        private readonly IMapper _mapper;

        public UpdateStockCommandHandler(IGenericRepository<Stock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<StockDTO>> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var existingResult = await _repository.GetByIdAsync(request.UpdatedStockDto.StockId);

            if (!existingResult.IsSuccess)
                return OperationResult<StockDTO>.Failure("Stock not found.");

            var existingEntity = existingResult.Data;

            // Map changes from DTO to existing entity
            _mapper.Map(request.UpdatedStockDto, existingEntity);

            var updateResult = await _repository.UpdateAsync(existingEntity);

            if (!updateResult.IsSuccess)
                return OperationResult<StockDTO>.Failure(updateResult.ErrorMessage);

            var updatedDto = _mapper.Map<StockDTO>(updateResult.Data);
            return OperationResult<StockDTO>.Success(updatedDto);
        }
    }
}
