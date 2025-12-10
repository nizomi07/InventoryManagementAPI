using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;

namespace InventoryManagementAPI.Services;

public interface ICategoryService
{
    Task<Response<Category>> AddCategoryAsync(AddCategoryDTO categoryDto);
    Task<Response<Category>> UpdateCategoryAsync(UpdateCategoryDTO categoryDto);
    Task DeleteCategoryAsync(long id);
    Task<Response<ResponseGetList<IEnumerable<Category>>>> GetAllCategoriesAsync(GetCategoryFilter f);
}