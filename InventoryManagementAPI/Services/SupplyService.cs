using System.Net;
using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Services;

    public class SupplyService(DataContext context, IMapper mapper) : ISupplyService
    {
        public async Task<Response<Supply>> AddSupplyAsync(AddSupplyDTO supplyDto)
        {
            var supply = mapper.Map<Supply>(supplyDto);
            context.Supplies.Add(supply);
            await context.SaveChangesAsync();

            return new Response<Supply>(HttpStatusCode.OK, "Supply added", supply);
        }

        public async Task<Response<Supply>> UpdateSupplyAsync(UpdateSupplyDTO supplyDto)
        {
            var supply = mapper.Map<Supply>(supplyDto);
            context.Supplies.Update(supply);
            await context.SaveChangesAsync();

            return new Response<Supply>(HttpStatusCode.OK, "Supply updated", supply);
        }

        public async Task DeleteSupplyAsync(long id)
        {
            var supply = await context.Supplies.FindAsync(id);
            if (supply != null)
            {
                context.Supplies.Remove(supply);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Response<ResponseGetList<IEnumerable<Supply>>>> GetAllSuppliesAsync(GetSupplyFilter f)
        {
            var query = context.Supplies.AsQueryable();

            if (f.Id.HasValue)
                query = query.Where(x => x.Id == f.Id.Value);

            if (f.Quantity.HasValue)
                query = query.Where(x => x.Quantity == f.Quantity.Value);

            if (f.SupplierId.HasValue)
                query = query.Where(x => x.SupplierId == f.SupplierId.Value);

            if (f.ProductId.HasValue)
                query = query.Where(x => x.ProductId == f.ProductId.Value);


            var totalRecords = await query.CountAsync();

            var data = await query
                .Skip((f.Page - 1) * f.Size)
                .Take(f.Size)
                .ToListAsync();

            return new Response<ResponseGetList<IEnumerable<Supply>>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Success",
                Content = new ResponseGetList<IEnumerable<Supply>>
                {
                    Data = data,
                    Page = f.Page,
                    Size = f.Size,
                    TotalRecords = totalRecords
                }
            };
        }
    }
