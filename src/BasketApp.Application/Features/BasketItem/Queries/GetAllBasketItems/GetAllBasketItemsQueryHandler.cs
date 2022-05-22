using AutoMapper;
using BasketApp.Application.Dtos;
using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Queries.GetAllBasketItems
{
    public class GetAllBasketItemsQueryHandler : IRequestHandler<GetAllBasketItemsRequest, GetAllBasketItemsResponse>
    {
        IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public GetAllBasketItemsQueryHandler(IBasketRepository _basketRepository, IMapper mapper)
        {
            basketRepository = _basketRepository ?? throw new ArgumentNullException(nameof(_basketRepository));
            this.mapper = mapper;
        }

        public async Task<GetAllBasketItemsResponse> Handle(GetAllBasketItemsRequest request, CancellationToken cancellationToken)
        {
            var basketItems = await basketRepository.GetAllListAsync(null, x => x.Product);
            var result = mapper.Map<List<BasketItemDto>>(basketItems);

            return new GetAllBasketItemsResponse() { Response = new ServiceResponse<List<BasketItemDto>>(result) };
        }
    }
}
