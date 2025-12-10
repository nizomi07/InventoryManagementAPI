using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Product>> AddProductAsync([FromBody] AddProductDTO productDto)
    {
        var createdProduct = await service.AddProductAsync(productDto);
        return Ok(createdProduct);
    }

    [HttpGet]
    
    public async Task<ActionResult<Response<ResponseGetList<IEnumerable<Product>>>>> GetAllProductsAsync([FromQuery] GetProductsFilter filter)
    {
        var products = await service.GetAllProductsAsync(filter);
        return Ok(products);
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProductAsync([FromBody] UpdateProductDTO productDto)
    {
        var updatedProduct = await service.UpdateProductAsync(productDto);
        return Ok(updatedProduct);
    }

    [HttpDelete]
    public async Task<ActionResult<Product>> DeleteProductAsync(long id)
    {
        await service.DeleteProductAsync(id);
        return Ok();
    }
}