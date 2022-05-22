using FluentValidation;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemRequest : IRequest<UpdateBasketItemResponse>
    {
        public Guid Id { get; set; }
        public int ProductCount { get; set; }
        public Guid ProductId { get; set; }
    }

    public class UpdateBasketItemRequestValidator : AbstractValidator<UpdateBasketItemRequest>
    {
        public UpdateBasketItemRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen Sepet ID Bilgisini Giriniz.");

            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Lütfen Ürün ID Bilgisini Giriniz.");

            RuleFor(x => x.ProductCount)
                .NotEmpty()
                .WithMessage("Lütfen Ürün Sayısı Bilgisini Giriniz.");
        }
    }
}
