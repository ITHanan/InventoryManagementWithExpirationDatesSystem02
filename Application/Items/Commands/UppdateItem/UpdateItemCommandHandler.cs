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

namespace ApplicationLayer.Items.Commands.UppdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, OperationResult<ItemDto>>
    {
        private readonly IGenericRepository<Item> _repository;

        private readonly IMapper _mapper;


        public UpdateItemCommandHandler(IGenericRepository<Item> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        public async Task<OperationResult<ItemDto>> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var existingResult = await _repository.GetByIdAsync(request.UpdatedItmeDto.ItemId);
            if (!existingResult.IsSuccess)
                return OperationResult<ItemDto>.Failure("Item not found.");

            var existingEntity = existingResult.Data;

            // Map changes from DTO to existing entity (tracked by EF)
            _mapper.Map(request.UpdatedItmeDto, existingEntity);

            var updateResult = await _repository.UpdateAsync(existingEntity);
            if (!updateResult.IsSuccess)
                return OperationResult<ItemDto>.Failure(updateResult.ErrorMessage);

            var updatedDto = _mapper.Map<ItemDto>(updateResult.Data);
            return OperationResult<ItemDto>.Success(updatedDto);
        }
    }
}
