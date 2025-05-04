using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Suppliers.Commands.CreateSuppliers;
using ApplicationLayer.Suppliers.Commands.DeleteSupplier;
using ApplicationLayer.Suppliers.Commands.UpdateSupplier;
using ApplicationLayer.Suppliers.Queries.GerSupplierByID;
using ApplicationLayer.Suppliers.Queries.GetCurrentSuppliers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/supplier
        [Authorize]
        [HttpGet("Get-All-Supplier")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSuppliersQuery());
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }

        // GET: api/supplier/{id}
        [Authorize]
        [HttpGet("{id} Get-Supplier-By-ID")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetSupplierByIdQuery(id));
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
        }

        // POST: api/supplier
        [HttpPost("Add-Supplier")]
        public async Task<IActionResult> Create([FromBody] SupplierDto supplierDto)
        {
            var result = await _mediator.Send(new CreateSupplierCommand(supplierDto));
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }

        // PUT: api/supplier/{id}
        [HttpPut("{id} Update-supplier")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierDto supplierDto)
        {
            if (id != supplierDto.SupplierId)
                return BadRequest("Supplier ID mismatch.");

            var result = await _mediator.Send(new UpdateSupplierCommand(supplierDto));
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }

        // DELETE: api/supplier/{id}
        [HttpDelete("{id} Delete-Supplier")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteSupplierCommand(id));
            return result.IsSuccess ? Ok(result.Data) : NotFound(result.ErrorMessage);
        }
    }
}
