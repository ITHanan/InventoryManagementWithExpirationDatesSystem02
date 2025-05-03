using ApplicationLayer.Interfaces.IGenericIRepository;
using DomainLayer.Models;
using DomainLayer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommandHandler : IRequestHandler<DeleteSupplierCommand, OperationResult<bool>>
    {
        private readonly IGenericRepository<Supplier> _repository;

        public DeleteSupplierCommandHandler(IGenericRepository<Supplier> repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult<bool>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteAsync(request.SupplierId);
        }
    }
}
