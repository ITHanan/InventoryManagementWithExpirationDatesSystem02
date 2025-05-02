using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;

namespace ApplicationLayer.Items.Commands
{
    public class AddItemCommand : IRequest<OperationResult<ItemDto>>
    {
        public ItemDto ItemDto { get; set; }

        public AddItemCommand(ItemDto itemDto)
        {
            ItemDto = itemDto;
        }
    }
}
