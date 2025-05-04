using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Stocks.Queries.GetCurrentStocks
{
    public class GetAllStockQuery:IRequest<OperationResult<IEnumerable<StockDTO>>>
    {
    }
}
