using AutoMapper;
using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using BasketApp.Domain.Entities;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemRequest, UpdateBasketItemResponse>
    {
        IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public UpdateBasketItemCommandHandler(IBasketRepository _basketRepository, IMapper mapper)
        {
            basketRepository = _basketRepository ?? throw new ArgumentNullException(nameof(_basketRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateBasketItemResponse> Handle(UpdateBasketItemRequest request, CancellationToken cancellationToken)
        {
            var basket = mapper.Map<Basket>(request);
            var returnValue = await basketRepository.Update(request.Id, basket);

            return new UpdateBasketItemResponse() { Response = new ServiceResponse<bool>(returnValue) };
        }
    }
}
