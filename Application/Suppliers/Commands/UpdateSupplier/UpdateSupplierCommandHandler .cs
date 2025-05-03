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

namespace ApplicationLayer.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommandHandler : IRequestHandler<UpdateSupplierCommand, OperationResult<SupplierDto>>
    {
        private readonly IGenericRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public UpdateSupplierCommandHandler(IGenericRepository<Supplier> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<SupplierDto>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.UpdatedSupplierDto.SupplierId);
            if (!result.IsSuccess)
                return OperationResult<SupplierDto>.Failure("Supplier not found.");

            var existingSupplier = result.Data;

            _mapper.Map(request.UpdatedSupplierDto, existingSupplier);

            var updateResult = await _repository.UpdateAsync(existingSupplier);
            if (!updateResult.IsSuccess)
                return OperationResult<SupplierDto>.Failure(updateResult.ErrorMessage);

            var updatedDto = _mapper.Map<SupplierDto>(updateResult.Data);
            return OperationResult<SupplierDto>.Success(updatedDto);
        }
    }
}
