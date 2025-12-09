using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;

namespace InventoryManagementAPI.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        
        CreateMap<AddProductDTO, Product>().ReverseMap();
        CreateMap<UpdateProductDTO, Product>().ReverseMap();
        
        // CreateMap<AddAuthorDto, Author>().ReverseMap();
        // CreateMap<AddBookDto, Book>().ReverseMap();
        // CreateMap<AddOrderDto, Order>().ReverseMap();
        // CreateMap<AddOrderBookDto, OrderBook>().ReverseMap();
        //
        // CreateMap<UpdateAuthorDto, Author>().ReverseMap();
        // CreateMap<UpdateBookDto, Book>().ReverseMap();
        // CreateMap<UpdateOrderDto, Order>().ReverseMap();
        // CreateMap<UpdateOrderBookDto, OrderBook>().ReverseMap();
    }
}