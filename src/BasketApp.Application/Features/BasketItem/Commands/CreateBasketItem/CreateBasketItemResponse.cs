using BasketApp.Application.Wrappers;

namespace BasketApp.Application.Features.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemResponse
    {
        public ServiceResponse<Guid> Response { get; set; }
    }
}
