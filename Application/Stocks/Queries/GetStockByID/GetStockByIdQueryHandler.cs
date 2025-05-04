using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.IGenericIRepository;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Queries
{
    public class GetStockByIdQueryHandler : IRequestHandler<GetStockByIdQuery, OperationResult<StockDTO>>
    {
        private readonly IGenericRepository<Stock> _repository;
        private readonly IMapper _mapper;

        public GetStockByIdQueryHandler(IGenericRepository<Stock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<StockDTO>> Handle(GetStockByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.StockId);

            if (!result.IsSuccess)
                return OperationResult<StockDTO>.Failure(result.ErrorMessage);

            var dto = _mapper.Map<StockDTO>(result.Data);
            return OperationResult<StockDTO>.Success(dto);
        }
    }
}
