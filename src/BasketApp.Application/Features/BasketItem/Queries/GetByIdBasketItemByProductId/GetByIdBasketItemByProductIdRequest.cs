using FluentValidation;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Queries.GetByIdBasketItemByProductId
{
    public class GetByIdBasketItemByProductIdRequest : IRequest<GetByIdBasketItemByProductIdResponse>
    {
        public Guid ProductId { get; set; }
    }

    public class GetByIdBasketItemByProductIdRequestValidator : AbstractValidator<GetByIdBasketItemByProductIdRequest>
    {
        public GetByIdBasketItemByProductIdRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Lütfen Ürün ID Bilgisini Giriniz.");
        }
    }
}
