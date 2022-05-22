using FluentValidation;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemRequest : IRequest<CreateBasketItemResponse>
    {
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }
    }

    public class CreateBasketItemRequestValidator : AbstractValidator<CreateBasketItemRequest>
    {
        public CreateBasketItemRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Lütfen Ürün ID Bilgisini Giriniz.");

            RuleFor(x => x.ProductCount)
                .NotEmpty()
                .WithMessage("Lütfen Ürün Sayısı Bilgisini Giriniz.");
        }
    }
}
