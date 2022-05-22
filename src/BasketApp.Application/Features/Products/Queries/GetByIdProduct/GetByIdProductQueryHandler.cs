using AutoMapper;
using BasketApp.Application.Dtos;
using BasketApp.Application.Interfaces.Repository;
using BasketApp.Application.Wrappers;
using MediatR;

namespace BasketApp.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductRequest, GetByIdProductResponse>
    {
        IProductRepository productRepository;
        private readonly IMapper mapper;

        public GetByIdProductQueryHandler(IProductRepository _productRepository, IMapper mapper)
        {
            productRepository = _productRepository ?? throw new ArgumentNullException(nameof(_productRepository));
            this.mapper = mapper;
        }

        public async Task<GetByIdProductResponse> Handle(GetByIdProductRequest request, CancellationToken cancellationToken)
        {
            var Product = await productRepository.GetByIdAsync(x => x.Id == request.ProductId);
            var result = mapper.Map<ProductDto>(Product);

            return new GetByIdProductResponse() { Response = new ServiceResponse<ProductDto>(result) };
        }
    }
}
