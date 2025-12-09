using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;

namespace InventoryManagementAPI.Services;

public interface IProductService
{
    Task<Response<Product>> AddProductAsync(AddProductDTO productDto);
    Task<Response<Product>> UpdateProductAsync(UpdateProductDTO productDto);
    Task DeleteProductAsync(long id);
    Task<Response<ResponseGetList<IEnumerable<Product>>>> GetAllProductsAsync(GetProductsFilter f);
}