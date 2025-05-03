using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Queries.GerSupplierByID
{
    public class GetSupplierByIdQuery : IRequest<OperationResult<SupplierDto>>
    {
        public int SupplierId { get; set; }

        public GetSupplierByIdQuery(int id)
        {
            SupplierId = id;
        }
    }

}
