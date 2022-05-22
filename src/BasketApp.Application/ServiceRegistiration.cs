using BasketApp.Application.Features.BasketItem.Commands.CreateBasketItem;
using BasketApp.Application.Features.BasketItem.Commands.DeleteBasketItem;
using BasketApp.Application.Features.BasketItem.Commands.UpdateBasketItem;
using BasketApp.Application.Features.BasketItem.Queries.GetByIdBasketItemByProductId;
using BasketApp.Application.Features.Products.Commands.UpdateProduct;
using BasketApp.Application.Features.Products.Queries.GetByIdProduct;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BasketApp.Application
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);
            services.AddMediatR(assm);
            services.AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<CreateBasketItemRequestValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<DeleteBasketItemRequestValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<UpdateBasketItemRequestValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<GetByIdBasketItemByProductIdRequestValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<UpdateProductRequestValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<GetByIdProductRequestValidator>();
            });
        }
    }
}
