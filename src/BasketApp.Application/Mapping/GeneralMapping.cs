using AutoMapper;
using BasketApp.Application.Dtos;
using BasketApp.Application.Features.BasketItem.Commands.CreateBasketItem;
using BasketApp.Application.Features.BasketItem.Commands.DeleteBasketItem;
using BasketApp.Application.Features.BasketItem.Commands.UpdateBasketItem;
using BasketApp.Application.Features.Products.Commands.UpdateProduct;
using BasketApp.Domain.Entities;

namespace BasketApp.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Basket, BasketItemDto>()
                .ForMember(dest => dest.ProductName, action => action.MapFrom(src => src.Product.ProductName))
                .ReverseMap();
            CreateMap<Basket, CreateBasketItemRequest>().ReverseMap();
            CreateMap<Basket, UpdateBasketItemRequest>().ReverseMap();
            CreateMap<Basket, DeleteBasketItemRequest>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductRequest>().ReverseMap();
        }
    }
}
