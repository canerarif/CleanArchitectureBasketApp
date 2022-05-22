using BasketApp.Application.Dtos;
using BasketApp.Application.Wrappers;

namespace BasketApp.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductResponse
    {
        public ServiceResponse<ProductDto> Response { get; set; }
    }
}
