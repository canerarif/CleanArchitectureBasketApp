using BasketApp.Application.Features.BasketItem.Commands.CreateBasketItem;
using BasketApp.Application.Features.BasketItem.Commands.DeleteBasketItem;
using BasketApp.Application.Features.BasketItem.Queries.GetAllBasketItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BasketApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IMediator mediator;
        public BasketController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        [HttpGet("GetAllBasketItems")]
        public async Task<IActionResult> GetAllBasketItems()
        {
            var query = new GetAllBasketItemsRequest();
            return Ok(await mediator.Send(query));
        }

        [HttpPost("CreateBasketItem")]
        public async Task<IActionResult> CreateBasketItem(CreateBasketItemRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost("DeleteBasketItem")]
        public async Task<IActionResult> DeleteBasketItem(DeleteBasketItemRequest request)
        {
            return Ok(await mediator.Send(request));
        }
    }
}
