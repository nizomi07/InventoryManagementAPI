using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;

namespace InventoryManagementAPI.Services;

public interface ISupplyService
{
    Task<Response<Supply>> AddSupplyAsync(AddSupplyDTO supplyDto);
    Task<Response<Supply>> UpdateSupplyAsync(UpdateSupplyDTO supplyDto);
    Task DeleteSupplyAsync(long id);
    Task<Response<ResponseGetList<IEnumerable<Supply>>>> GetAllSuppliesAsync(GetSupplyFilter f);
}