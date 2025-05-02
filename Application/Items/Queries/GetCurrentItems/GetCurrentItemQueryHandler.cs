using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.ItemInterface;
using DomainLayer;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Items.Queries.GetCurrentItems
{
    public class GetCurrentItemQueryHandler : IRequestHandler<GetCurrentItemQuery, OperationResult<IEnumerable<ItemDto>>>
    {
        private readonly IItemRepository _itemRepository;

        public GetCurrentItemQueryHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<OperationResult<IEnumerable<ItemDto>>> Handle(GetCurrentItemQuery request, CancellationToken cancellationToken)
        {
            // Step 1: await the first task
            var resultWithTask = await _itemRepository.GetAllItemsAsync();

            // Step 2: check if it failed early
            if (!resultWithTask.IsSuccess || resultWithTask.Data == null)
                return OperationResult<IEnumerable<ItemDto>>.Failure(resultWithTask.ErrorMessage ?? "Unknown error");

            // Step 3: await the inner task to get actual data
            var items = await resultWithTask.Data;

            return OperationResult<IEnumerable<ItemDto>>.Success(items);
        }
    }
}
