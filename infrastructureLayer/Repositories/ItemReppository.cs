using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Interfaces.ItemInterface;
using AutoMapper;
using DomainLayer;
using DomainLayer.Models;
using infrastructureLayer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureLayer.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ItemRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult<Task<ItemDto>>> GetItemByIdAsync(int itemId)
        {
            try
            {
                var item = await _context.Items.FindAsync(itemId);
                if (item == null)
                    return OperationResult<Task<ItemDto>>.Failure("Item not found.");

                var dto = _mapper.Map<ItemDto>(item);
                return OperationResult<Task<ItemDto>>.Success(Task.FromResult(dto));
            }
            catch (Exception ex)
            {
                return OperationResult<Task<ItemDto>>.Failure(ex.Message);
            }
        }

        public async Task<OperationResult<Task<IEnumerable<ItemDto>>>> GetAllItemsAsync()
        {
            try
            {
                var items = await _context.Items.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<ItemDto>>(items);
                return OperationResult<Task<IEnumerable<ItemDto>>>.Success(Task.FromResult(dtos));
            }
            catch (Exception ex)
            {
                return OperationResult<Task<IEnumerable<ItemDto>>>.Failure(ex.Message);
            }
        }

        public async Task<OperationResult<Task<ItemDto>>> AddItemAsync(ItemDto itemDto)
        {
            try
            {
                var entity = _mapper.Map<Item>(itemDto);
                await _context.Items.AddAsync(entity);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ItemDto>(entity);
                return OperationResult<Task<ItemDto>>.Success(Task.FromResult(dto));
            }
            catch (Exception ex)
            {
                return OperationResult<Task<ItemDto>>.Failure(ex.Message);
            }
        }

        public async Task<OperationResult<Task<ItemDto>>> UpdateItemAsync(int id, ItemDto itemDto)
        {
            try
            {
                var entity = await _context.Items.FindAsync(id);
                if (entity == null)
                    return OperationResult<Task<ItemDto>>.Failure("Item not found.");

                _mapper.Map(itemDto, entity);
                _context.Items.Update(entity);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ItemDto>(entity);
                return OperationResult<Task<ItemDto>>.Success(Task.FromResult(dto));
            }
            catch (Exception ex)
            {
                return OperationResult<Task<ItemDto>>.Failure(ex.Message);
            }
        }

        public async Task<OperationResult<Task<bool>>> DeleteItemAsync(int itemId)
        {
            try
            {
                var entity = await _context.Items.FindAsync(itemId);
                if (entity == null)
                    return OperationResult<Task<bool>>.Failure("Item not found.");

                _context.Items.Remove(entity);
                await _context.SaveChangesAsync();

                return OperationResult<Task<bool>>.Success(Task.FromResult(true));
            }
            catch (Exception ex)
            {
                return OperationResult<Task<bool>>.Failure(ex.Message);
            }
        }

        public async Task<OperationResult<Task<ItemDto>>> UpdateItemUnitPriceAsync(int id, decimal newUnitPrice)
        {
            try
            {
                var entity = await _context.Items.FindAsync(id);
                if (entity == null)
                    return OperationResult<Task<ItemDto>>.Failure("Item not found.");

                entity.UnitPrice = newUnitPrice;
                _context.Items.Update(entity);
                await _context.SaveChangesAsync();

                var dto = _mapper.Map<ItemDto>(entity);
                return OperationResult<Task<ItemDto>>.Success(Task.FromResult(dto));
            }
            catch (Exception ex)
            {
                return OperationResult<Task<ItemDto>>.Failure(ex.Message);
            }
        }
    }
}
