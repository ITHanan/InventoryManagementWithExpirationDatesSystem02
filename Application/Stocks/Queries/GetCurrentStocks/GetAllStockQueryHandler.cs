using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.IGenericIRepository;
using AutoMapper;
using DomainLayer.Models;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Queries.GetCurrentStocks
{
    public class GetAllStockHandler : IRequestHandler<GetAllStockQuery, OperationResult<IEnumerable<StockDTO>>>
    {
        private readonly IGenericRepository<Stock> _stockRepository;
        private readonly IMapper _mapper;

        public GetAllStockHandler(IGenericRepository<Stock> stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }


        public async Task<OperationResult<IEnumerable<StockDTO>>> Handle(GetAllStockQuery request, CancellationToken cancellationToken)
        {
            var result = await _stockRepository.GetAllAsync();

            if (!result.IsSuccess)
                return OperationResult<IEnumerable<StockDTO>>.Failure(result.ErrorMessage);

            var dtos = _mapper.Map<IEnumerable<StockDTO>>(result.Data);
            return OperationResult<IEnumerable<StockDTO>>.Success(dtos);
        }
    }
}
