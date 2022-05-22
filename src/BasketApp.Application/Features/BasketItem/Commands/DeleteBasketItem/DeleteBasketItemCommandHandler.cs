using AutoMapper;
using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using BasketApp.Domain.Entities;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemRequest, DeleteBasketItemResponse>
    {
        IBasketRepository basketRepository;
        private readonly IMapper mapper;

        public DeleteBasketItemCommandHandler(IBasketRepository _basketRepository, IMapper mapper)
        {
            this.basketRepository = _basketRepository ?? throw new ArgumentNullException(nameof(_basketRepository));
            this.mapper = mapper;
        }

        public async Task<DeleteBasketItemResponse> Handle(DeleteBasketItemRequest request, CancellationToken cancellationToken)
        {
            var basket = mapper.Map<Basket>(request);
            var returnValue = await basketRepository.Delete(basket);

            return new DeleteBasketItemResponse() { Response = new ServiceResponse<bool>(returnValue) };
        }
    }
}
