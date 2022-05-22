using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using BasketApp.Domain.Entities;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Queries.GetByIdBasketItemByProductId
{
    public class GetByIdBasketItemByProductIdQueryHandler : IRequestHandler<GetByIdBasketItemByProductIdRequest, GetByIdBasketItemByProductIdResponse>
    {
        IBasketRepository basketRepository;

        public GetByIdBasketItemByProductIdQueryHandler(IBasketRepository _basketRepository)
        {
            basketRepository = _basketRepository ?? throw new ArgumentNullException(nameof(_basketRepository));
        }

        public async Task<GetByIdBasketItemByProductIdResponse> Handle(GetByIdBasketItemByProductIdRequest request, CancellationToken cancellationToken)
        {
            var basketEntity = await basketRepository.GetByIdAsync(x => x.ProductId == request.ProductId);

            return new GetByIdBasketItemByProductIdResponse() { Response = new ServiceResponse<Basket>(basketEntity) };
        }
    }
}
