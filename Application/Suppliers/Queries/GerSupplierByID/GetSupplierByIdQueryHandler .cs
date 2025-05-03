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

namespace ApplicationLayer.Suppliers.Queries.GerSupplierByID
{
    public class GetSupplierByIdQueryHandler : IRequestHandler<GetSupplierByIdQuery, OperationResult<SupplierDto>>
    {
        private readonly IGenericRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public GetSupplierByIdQueryHandler(IGenericRepository<Supplier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<SupplierDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.SupplierId);

            if (!result.IsSuccess)
                return OperationResult<SupplierDto>.Failure(result.ErrorMessage);

            var dto = _mapper.Map<SupplierDto>(result.Data);
            return OperationResult<SupplierDto>.Success(dto);
        }
    }

}
