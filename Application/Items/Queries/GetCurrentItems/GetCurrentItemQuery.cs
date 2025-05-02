using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using DomainLayer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Items.Queries.GetCurrentItems
{
    public class GetCurrentItemQuery : IRequest<OperationResult<IEnumerable<ItemDto>>>
    {
    }
}
