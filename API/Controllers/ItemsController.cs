﻿using ApplicationLayer.ACommen.DTOs;
using ApplicationLayer.Items.Commands;
using ApplicationLayer.Items.Commands.DeleteItem;
using ApplicationLayer.Items.Commands.UppdateItem;
using ApplicationLayer.Items.Queries.GetCurrentItems;
using ApplicationLayer.Items.Queries.GetItemById;
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

        [HttpGet("get-by-id/{itemId}")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            var result = await _mediator.Send(new GetItemByIDQuery(itemId));
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddItem([FromBody] ItemDto itemDto)
        {
            var result = await _mediator.Send(new AddItemCommand(itemDto));
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] ItemDto itemDto)
        {
            var result = await _mediator.Send(new UpdateItemCommand( id, itemDto));
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var result = await _mediator.Send(new DeleteItemCommand(id));
            return Ok(result);
        }



    }
}
