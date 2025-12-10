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

        CreateMap<AddCategoryDTO, Category>().ReverseMap();
        CreateMap<UpdateCategoryDTO, Category>().ReverseMap();

        CreateMap<AddSupplierDTO, Supplier>().ReverseMap();
        CreateMap<UpdateSupplierDTO, Supplier>().ReverseMap();
        
        CreateMap<AddSupplyDTO, Supply>().ReverseMap();
        CreateMap<UpdateSupplyDTO, Supply>().ReverseMap();
    }
}