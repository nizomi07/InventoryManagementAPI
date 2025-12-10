using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(ICategoryService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Category>> AddCategoryAsync([FromBody] AddCategoryDTO categoryDto)
    {
        var createdCategory = await service.AddCategoryAsync(categoryDto);
        return Ok(createdCategory);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetAllCategorysAsync([FromBody] GetCategoryFilter filter)
    {
        var categories = await service.GetAllCategoriesAsync(filter);
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Category>> UpdateCategoryAsync([FromBody] UpdateCategoryDTO categoryDto)
    {
        var updatedCategory = await service.UpdateCategoryAsync(categoryDto);
        return Ok(updatedCategory);
    }

    [HttpDelete]
    public async Task<ActionResult<Category>> DeleteCategoryAsync(long id)
    {
        await service.DeleteCategoryAsync(id);
        return Ok();
    }
}