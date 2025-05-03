using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierCommand : IRequest<OperationResult<SupplierDto>>
    {
        public SupplierDto UpdatedSupplierDto { get; set; }

        public UpdateSupplierCommand(SupplierDto updatedSupplierDto)
        {
            UpdatedSupplierDto = updatedSupplierDto;
        }
    }
}
