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

namespace ApplicationLayer.Suppliers.Commands.CreateSuppliers
{
    public class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, OperationResult<SupplierDto>>
    {
        private readonly IGenericRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public CreateSupplierCommandHandler(IGenericRepository<Supplier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<SupplierDto>> Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Supplier>(request.SupplierDto);
            var result = await _repository.AddAsync(entity);

            if (!result.IsSuccess)
                return OperationResult<SupplierDto>.Failure(result.ErrorMessage);

            var dto = _mapper.Map<SupplierDto>(result.Data);
            return OperationResult<SupplierDto>.Success(dto);
        }
    }

}
