using ApplicationLayer.ACommen.DTOs;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Commands.CreateSuppliers
{
    public class CreateSupplierCommand : IRequest<OperationResult<SupplierDto>>
    {
        public string supplierName;

        public SupplierDto SupplierDto { get; set; }
        public string Email { get; set; }

        public CreateSupplierCommand(SupplierDto dto)
        {
            SupplierDto = dto;
        }
    }

}
