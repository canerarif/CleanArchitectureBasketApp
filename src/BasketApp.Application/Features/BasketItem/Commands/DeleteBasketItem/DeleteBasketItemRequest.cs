using FluentValidation;
using MediatR;

namespace BasketApp.Application.Features.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemRequest : IRequest<DeleteBasketItemResponse>
    {
        public Guid Id { get; set; }
    }

    public class DeleteBasketItemRequestValidator : AbstractValidator<DeleteBasketItemRequest>
    {
        public DeleteBasketItemRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen Sepet Ürün ID Bilgisini Giriniz.");
        }
    }
}
