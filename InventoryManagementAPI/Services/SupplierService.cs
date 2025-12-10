using System.Net;
using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Services;

    public class SupplierService(DataContext context, IMapper mapper) : ISupplierService
    {
        public async Task<Response<Supplier>> AddSupplierAsync(AddSupplierDTO supplierDto)
        {
            var supplier = mapper.Map<Supplier>(supplierDto);
            context.Suppliers.Add(supplier);
            await context.SaveChangesAsync();

            return new Response<Supplier>(HttpStatusCode.OK, "Supplier added", supplier);
        }

        public async Task<Response<Supplier>> UpdateSupplierAsync(UpdateSupplierDTO supplierDto)
        {
            var supplier = mapper.Map<Supplier>(supplierDto);
            context.Suppliers.Update(supplier);
            await context.SaveChangesAsync();

            return new Response<Supplier>(HttpStatusCode.OK, "Supplier updated", supplier);
        }

        public async Task DeleteSupplierAsync(long id)
        {
            var supplier = await context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                context.Suppliers.Remove(supplier);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Response<ResponseGetList<IEnumerable<Supplier>>>> GetAllSuppliersAsync(GetSupplierFilter f)
        {
            var query = context.Suppliers.AsQueryable();

            if (f.Id.HasValue)
                query = query.Where(x => x.Id == f.Id.Value);

            if (!string.IsNullOrEmpty(f.CompanyName))
                query = query.Where(x => x.CompanyName.ToLower().Contains(f.CompanyName.ToLower()));

            if (!string.IsNullOrEmpty(f.Email))
                query = query.Where(x => x.Email.ToLower().Contains(f.Email.ToLower()));

            if (!string.IsNullOrEmpty(f.PhoneNumber))
                query = query.Where(x => x.PhoneNumber.ToLower().Contains(f.PhoneNumber.ToLower()));

            var totalRecords = await query.CountAsync();

            var data = await query
                .Skip((f.Page - 1) * f.Size)
                .Take(f.Size)
                .ToListAsync();

            return new Response<ResponseGetList<IEnumerable<Supplier>>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Success",
                Content = new ResponseGetList<IEnumerable<Supplier>>
                {
                    Data = data,
                    Page = f.Page,
                    Size = f.Size,
                    TotalRecords = totalRecords
                }
            };
        }
    }
