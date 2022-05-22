using FluentValidation;
using MediatR;

namespace BasketApp.Application.Features.Products.Queries.GetByIdProduct
{
    public class GetByIdProductRequest : IRequest<GetByIdProductResponse>
    {
        public Guid ProductId { get; set; }
    }

    public class GetByIdProductRequestValidator : AbstractValidator<GetByIdProductRequest>
    {
        public GetByIdProductRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Lütfen Ürün ID Bilgisini Giriniz.");
        }
    }
}
