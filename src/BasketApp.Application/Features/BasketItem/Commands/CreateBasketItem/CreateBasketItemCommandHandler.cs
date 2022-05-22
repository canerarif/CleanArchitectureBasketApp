using AutoMapper;
using BasketApp.Application.Features.BasketItem.Commands.UpdateBasketItem;
using BasketApp.Application.Features.BasketItem.Queries.GetByIdBasketItemByProductId;
using BasketApp.Application.Features.Products.Commands.UpdateProduct;
using BasketApp.Application.Features.Products.Queries.GetByIdProduct;
using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using BasketApp.Domain.Entities;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandler : IRequestHandler<CreateBasketItemRequest, CreateBasketItemResponse>
    {
        IBasketRepository basketRepository;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public CreateBasketItemCommandHandler(IBasketRepository _basketRepository, IMapper mapper, IMediator _mediator)
        {
            basketRepository = _basketRepository ?? throw new ArgumentNullException(nameof(_basketRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.mediator = _mediator ?? throw new ArgumentNullException(nameof(_mediator));
        }

        public async Task<CreateBasketItemResponse> Handle(CreateBasketItemRequest request, CancellationToken cancellationToken)
        {
            GetByIdProductResponse getByIdProductResponse = await BasketValidations(request);

            Guid createdOrUpdatedBasketItemId;
            GetByIdBasketItemByProductIdResponse getByIdBasketItemByProductIdResponse = await mediator.Send(new GetByIdBasketItemByProductIdRequest() { ProductId = request.ProductId });
            // Eğer sepete eklenmek istenen ürün zaten sepette varsa...
            if (getByIdBasketItemByProductIdResponse.Response.Value != null)
            {
                getByIdBasketItemByProductIdResponse.Response.Value.ProductCount += request.ProductCount;

                // Basket tablosundaki ProductCount güncelleniyor.
                await mediator.Send(new UpdateBasketItemRequest()
                {
                    Id = getByIdBasketItemByProductIdResponse.Response.Value.Id,
                    ProductCount = getByIdBasketItemByProductIdResponse.Response.Value.ProductCount,
                    ProductId = getByIdBasketItemByProductIdResponse.Response.Value.ProductId
                });

                createdOrUpdatedBasketItemId = getByIdBasketItemByProductIdResponse.Response.Value.Id;
            }
            else
            {
                //Basket tablosuna insert işlemi yapılıyor.
                var basket = mapper.Map<Basket>(request);
                var returnValue = await basketRepository.AddAsync(basket);
                createdOrUpdatedBasketItemId = returnValue.Id;
            }

            // Product tablosundan stok düşülüyor.
            await mediator.Send(new UpdateProductRequest()
            {
                Id = getByIdProductResponse.Response.Value.Id,
                ProductName = getByIdProductResponse.Response.Value.ProductName,
                Stock = getByIdProductResponse.Response.Value.Stock - request.ProductCount
            });

            return new CreateBasketItemResponse() { Response = new ServiceResponse<Guid>(createdOrUpdatedBasketItemId) };

        }

        private async Task<GetByIdProductResponse> BasketValidations(CreateBasketItemRequest request)
        {
            GetByIdProductResponse getByIdProductResponse = await mediator.Send(new GetByIdProductRequest() { ProductId = request.ProductId });
            if (getByIdProductResponse.Response.Value == null)
                throw new Exception("Ürün Bulunamadı..");
            if (request.ProductCount > getByIdProductResponse.Response.Value.Stock)
                throw new Exception("Sepete eklenmek istenen ürün sayısı ürün stoğundan daha fazladır..");
            return getByIdProductResponse;
        }
    }
}
