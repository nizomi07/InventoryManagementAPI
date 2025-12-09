using System.Net;
using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Services;

public class ProductService(DataContext context, IMapper mapper) : IProductService
{
    public async Task<Response<Product>> AddProductAsync(AddProductDTO productDto)
    {
        var product = mapper.Map<Product>(productDto);
        context.Products.Add(product);
        await context.SaveChangesAsync();
        return new Response<Product>(HttpStatusCode.OK, "Product added", product);
    }

    public async Task<Response<Product>> UpdateProductAsync(UpdateProductDTO productDto)
    {
        var product = mapper.Map<Product>(productDto);
        context.Products.Update(product);
        await context.SaveChangesAsync();
        return new Response<Product>(HttpStatusCode.OK, "Product updated", product);
    }

    public async Task DeleteProductAsync(long id)
    {
        var product = await context.Products.FindAsync(id);
        if (product != null)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }

    public async Task<Response<ResponseGetList<IEnumerable<Product>>>> GetAllProductsAsync(GetProductsFilter f)
    {
        var query = context.Products.AsQueryable();

        if (f.Id.HasValue)
            query = query.Where(x => x.Id == f.Id.Value);

        if (f.CategoryId.HasValue)
            query = query.Where(x => x.CategoryId == f.CategoryId.Value);

        if (!string.IsNullOrEmpty(f.Name))
            query = query.Where(x => x.Name.ToLower().Contains(f.Name.ToLower()));

        if (!string.IsNullOrEmpty(f.Description))
            query = query.Where(x => x.Description!.ToLower().Contains(f.Description.ToLower()));


        var totalRecords = await query.CountAsync();

        var data = await query
            .Skip((f.Page - 1) * f.Size)
            .Take(f.Size)
            .ToListAsync();

        return new Response<ResponseGetList<IEnumerable<Product>>>
        {
            StatusCode = (int)HttpStatusCode.OK,
            Message = "Success",
            Content = new ResponseGetList<IEnumerable<Product>>
            {
                Data = data,
                Page = f.Page,
                Size = f.Size,
                TotalRecords = totalRecords
            }
        };
    }
}