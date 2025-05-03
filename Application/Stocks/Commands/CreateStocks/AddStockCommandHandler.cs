using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.IGenericIRepository;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Commands.CreateStocks
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, OperationResult<StockDTO>>
    {
        private readonly IGenericRepository<Stock> _repository;
        private readonly IMapper _mapper;

        public AddStockCommandHandler(IGenericRepository<Stock> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public  async Task<OperationResult<StockDTO>> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {

            


            var entity = _mapper.Map<Stock>(request.StockDto);
            var result = await _repository.AddAsync(entity);
            if (!result.IsSuccess)
                return OperationResult<StockDTO>.Failure(result.ErrorMessage);

            var dto = _mapper.Map<StockDTO>(result.Data);
            return OperationResult<StockDTO>.Success(dto);
        }
    }
}
