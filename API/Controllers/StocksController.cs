using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Items.Commands;
using ApplicationLayer.Stocks.Commands;
using ApplicationLayer.Stocks.Commands.CreateStocks;
using ApplicationLayer.Stocks.Commands.DeletStock;
using ApplicationLayer.Stocks.Queries;
using ApplicationLayer.Stocks.Queries.GetCurrentStocks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StocksController(IMediator mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var result = await _mediator.Send(new GetAllStockQuery());
            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            var result = await _mediator.Send(new GetStockByIdQuery(id));
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }


       // [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddStock([FromBody] StockDTO stockDto)
        {
            var result = await _mediator.Send(new AddStockCommand(stockDto));
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] StockDTO stockDto)
        {
            if (id != stockDto.StockId)
                return BadRequest("Mismatched Stock ID");

            var result = await _mediator.Send(new UpdateStockCommand(stockDto));
            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var result = await _mediator.Send(new DeleteStockCommand(id));
            if (!result.IsSuccess)
                return NotFound(result.ErrorMessage);

            return Ok(result);
        }
    }
}
