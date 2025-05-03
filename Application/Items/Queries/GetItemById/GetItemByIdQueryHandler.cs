using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.IGenericIRepository;
using ApplicationLayer.Interfaces.ItemInterface;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using MediatR;

namespace ApplicationLayer.Items.Queries.GetItemById
{
    public class GetItemByIDQueryHandler : IRequestHandler<GetItemByIDQuery, OperationResult<ItemDto>>
    {
        private readonly IGenericRepository<Item> _repository;
        private readonly IMapper _mapper;

        public GetItemByIDQueryHandler(IGenericRepository<Item> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OperationResult<ItemDto>> Handle(GetItemByIDQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetByIdAsync(request.Id);

            if (!result.IsSuccess)
                return OperationResult<ItemDto>.Failure(result.ErrorMessage);

            // Map only the entity to DTO
            var dto = _mapper.Map<ItemDto>(result.Data);
            return OperationResult<ItemDto>.Success(dto);
        }


    }
}
