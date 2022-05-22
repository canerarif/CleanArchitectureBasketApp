using AutoMapper;
using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using BasketApp.Domain.Entities;
using MediatR;

namespace BasketApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
    {
        IProductRepository productRepository;
        private readonly IMapper mapper;

        public UpdateProductCommandHandler(IProductRepository _productRepository, IMapper mapper)
        {
            productRepository = _productRepository ?? throw new ArgumentNullException(nameof(_productRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            var returnValue = await productRepository.Update(request.Id, product);

            return new UpdateProductResponse() { Response = new ServiceResponse<bool>(returnValue) };
        }
    }
}
