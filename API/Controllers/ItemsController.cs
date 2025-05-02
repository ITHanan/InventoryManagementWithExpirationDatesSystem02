using ApplicationLayer.Items.Queries.GetCurrentItems;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("Get-All-Item")]
        public async Task<ActionResult> GetCurrentItem() 
        {
            var result = await _mediator.Send(new GetCurrentItemQuery());
            return Ok(result);  
        
        }

    }
}
