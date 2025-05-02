using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Interfaces.ItemInterface
{
    public interface IItemRepository
    {
        public Task<OperationResult<Task<ItemDto>>> GetItemByIdAsync(int itemId);      // Get a single item by its ID
        public Task<OperationResult<Task<IEnumerable<ItemDto>>>> GetAllItemsAsync();   // Get a list of all items
        public Task<OperationResult<Task<ItemDto>>> AddItemAsync(ItemDto itemDto);     // Add a new item
        public Task<OperationResult<Task<ItemDto>>> UpdateItemAsync(int id, ItemDto itemDto);  // Update an existing item
        public Task<OperationResult<Task<bool>>> DeleteItemAsync(int itemId);          // Delete an item by its ID
        public Task<OperationResult<Task<ItemDto>>> UpdateItemUnitPriceAsync(int id, decimal newUnitPrice);
    }
}
