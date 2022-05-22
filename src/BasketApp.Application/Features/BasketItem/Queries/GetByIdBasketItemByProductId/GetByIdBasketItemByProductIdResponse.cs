using BasketApp.Application.Wrappers;
using BasketApp.Domain.Entities;

namespace BasketApp.Application.Features.BasketItem.Queries.GetByIdBasketItemByProductId
{
    public class GetByIdBasketItemByProductIdResponse
    {
        public ServiceResponse<Basket> Response { get; set; }
    }
}
