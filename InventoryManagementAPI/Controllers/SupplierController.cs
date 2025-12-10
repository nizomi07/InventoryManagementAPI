using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SupplierController(ISupplierService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Supplier>> AddSupplierAsync([FromBody] AddSupplierDTO supplierDto)
    {
        var createdSupplier = await service.AddSupplierAsync(supplierDto);
        return Ok(createdSupplier);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Supplier>>> GetAllSuppliersAsync([FromBody] GetSupplierFilter filter)
    {
        var categories = await service.GetAllSuppliersAsync(filter);
        return Ok(categories);
    }

    [HttpPut]
    public async Task<ActionResult<Supplier>> UpdateSupplierAsync([FromBody] UpdateSupplierDTO supplierDto)
    {
        var updatedSupplier = await service.UpdateSupplierAsync(supplierDto);
        return Ok(updatedSupplier);
    }

    [HttpDelete]
    public async Task<ActionResult<Supplier>> DeleteSupplierAsync(long id)
    {
        await service.DeleteSupplierAsync(id);
        return Ok();
    }
}