using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Items.Commands.UppdateItem
{
    public class UpdateItemCommand : IRequest<OperationResult<ItemDto>>
    {
        public ItemDto UpdatedItmeDto { get; set; }
        public int Id { get; set; }

        public UpdateItemCommand(int id, ItemDto updatedItem)
        {
            UpdatedItmeDto = updatedItem; 
            Id = id;    
        }
    }
}
