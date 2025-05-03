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

namespace ApplicationLayer.Suppliers.Queries.GetCurrentSuppliers
{
    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, OperationResult<IEnumerable<SupplierDto>>>
    {
        private readonly IGenericRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public GetAllSuppliersQueryHandler(IGenericRepository<Supplier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<IEnumerable<SupplierDto>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync();

            if (!result.IsSuccess)
                return OperationResult<IEnumerable<SupplierDto>>.Failure(result.ErrorMessage);

            var dtos = _mapper.Map<IEnumerable<SupplierDto>>(result.Data);
            return OperationResult<IEnumerable<SupplierDto>>.Success(dtos);
        }
    }

}
