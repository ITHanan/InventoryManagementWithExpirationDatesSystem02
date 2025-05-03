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

namespace ApplicationLayer.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, OperationResult<ItemDto>>
    {
        private readonly IGenericRepository<Item> _repository; 
        
        private readonly IMapper _mapper;

        public DeleteItemCommandHandler(IGenericRepository<Item> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<OperationResult<ItemDto>> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var getResult = await _repository.GetByIdAsync(request.Id);
            if (!getResult.IsSuccess || getResult.Data == null)
                return OperationResult<ItemDto>.Failure("Item not found.");

            var deleteResult = await _repository.DeleteAsync(request.Id);
            if (!deleteResult.IsSuccess)
                return OperationResult<ItemDto>.Failure(deleteResult.ErrorMessage);

            var dto = _mapper.Map<ItemDto>(getResult.Data);
            return OperationResult<ItemDto>.Success(dto);
        }
    }
}
