using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Queries.GetCurrentSuppliers
{
    public class GetAllSuppliersQuery : IRequest<OperationResult<IEnumerable<SupplierDto>>> { }

}
