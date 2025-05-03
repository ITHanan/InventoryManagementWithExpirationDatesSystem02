using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Items.Queries.GetItemById
{
    public class GetItemByIDQuery : IRequest<OperationResult<ItemDto>>
    {
        public int Id { get; }

        public GetItemByIDQuery(int id)
        {
            Id = id;
        }
    }
}
