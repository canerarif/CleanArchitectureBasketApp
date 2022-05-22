using BasketApp.Application.Dtos;
using BasketApp.Application.Wrappers;

namespace BasketApp.Application.Features.BasketItem.Queries.GetAllBasketItems
{
    public class GetAllBasketItemsResponse
    {
        public ServiceResponse<List<BasketItemDto>> Response { get; set; }
    }
}
