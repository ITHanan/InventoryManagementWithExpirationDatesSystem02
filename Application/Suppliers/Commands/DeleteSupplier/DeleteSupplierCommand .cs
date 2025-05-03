using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<OperationResult<bool>>
    {
        public int SupplierId { get; set; }

        public DeleteSupplierCommand(int supplierId)
        {
            SupplierId = supplierId;
        }
    }
}
