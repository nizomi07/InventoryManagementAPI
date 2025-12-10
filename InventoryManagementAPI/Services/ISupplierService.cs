using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;

namespace InventoryManagementAPI.Services;

public interface ISupplierService
{
    Task<Response<Supplier>> AddSupplierAsync(AddSupplierDTO supplierDto);
    Task<Response<Supplier>> UpdateSupplierAsync(UpdateSupplierDTO supplierDto);
    Task DeleteSupplierAsync(long id);
    Task<Response<ResponseGetList<IEnumerable<Supplier>>>> GetAllSuppliersAsync(GetSupplierFilter f);
}