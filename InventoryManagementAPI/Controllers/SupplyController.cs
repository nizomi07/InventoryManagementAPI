using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplyController(ISupplyService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Supply>> AddSupplyAsync([FromBody] AddSupplyDTO supplyDto)
    {
        var createdSupply = await service.AddSupplyAsync(supplyDto);
        return Ok(createdSupply);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supply>>> GetAllSupplysAsync([FromBody] GetSupplyFilter filter)
    {
        var categories = await service.GetAllSuppliesAsync(filter);
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Supply>> UpdateSupplyAsync([FromBody] UpdateSupplyDTO supplyDto)
    {
        var updatedSupply = await service.UpdateSupplyAsync(supplyDto);
        return Ok(updatedSupply);
    }

    [HttpDelete]
    public async Task<ActionResult<Supply>> DeleteSupplyAsync(long id)
    {
        await service.DeleteSupplyAsync(id);
        return Ok();
    }
}