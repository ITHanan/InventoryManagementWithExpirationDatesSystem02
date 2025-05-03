using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<OperationResult<ItemDto>>
    {
        public int Id { get; set; }

        public DeleteItemCommand(int id)
        {
            Id = id;    
        }
    }
}
