using FluentValidation;
using MediatR;

namespace BasketApp.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductRequest : IRequest<UpdateProductResponse>
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
    }

    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Lütfen Ürün ID Bilgisini Giriniz.");

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Lütfen Ürün Adı Bilgisini Giriniz.");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .WithMessage("Lütfen Ürün Stok Bilgisini Giriniz.");
        }
    }
}
