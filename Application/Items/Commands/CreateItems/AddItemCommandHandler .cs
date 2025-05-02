using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.IGenericIRepository;
using ApplicationLayer.Interfaces.ItemInterface;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Items.Commands
{
    public class AddItemCommandHandler : IRequestHandler<AddItemCommand, OperationResult<ItemDto>>
    {
        private readonly IGenericRepository<Item> _repository;
        private readonly IMapper _mapper;

        public AddItemCommandHandler(IGenericRepository<Item> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<ItemDto>> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var item = _mapper.Map<Item>(request.ItemDto);
                await _repository.AddAsync(item);

                var dto = _mapper.Map<ItemDto>(item);
                return OperationResult<ItemDto>.Success(dto);
            }
            catch (Exception ex)
            {
                return OperationResult<ItemDto>.Failure(ex.Message);
            }
        }
    }

}