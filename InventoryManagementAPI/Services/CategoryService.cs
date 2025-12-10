using System.Net;
using AutoMapper;
using InventoryManagementAPI.DTOs;
using InventoryManagementAPI.Entities;
using InventoryManagementAPI.Filters;
using InventoryManagementAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Services;
    
    public class CategoryService(DataContext context, IMapper mapper) : ICategoryService
    {
        public async Task<Response<Category>> AddCategoryAsync(AddCategoryDTO categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            context.Categories.Add(category);
            await context.SaveChangesAsync();

            return new Response<Category>(HttpStatusCode.OK, "Category added", category);
        }

        public async Task<Response<Category>> UpdateCategoryAsync(UpdateCategoryDTO categoryDto)
        {
            var category = mapper.Map<Category>(categoryDto);
            context.Categories.Update(category);
            await context.SaveChangesAsync();

            return new Response<Category>(HttpStatusCode.OK, "Category updated", category);
        }

        public async Task DeleteCategoryAsync(long id)
        {
            var category = await context.Categories.FindAsync(id);
            if (category != null)
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Response<ResponseGetList<IEnumerable<Category>>>> GetAllCategoriesAsync(GetCategoryFilter f)
        {
            var query = context.Categories.AsQueryable();

            if (f.Id.HasValue)
                query = query.Where(x => x.Id == f.Id.Value);

            if (!string.IsNullOrEmpty(f.Name))
                query = query.Where(x => x.Name.ToLower().Contains(f.Name.ToLower()));

            if (!string.IsNullOrEmpty(f.Description))
                query = query.Where(x => x.Description!.ToLower().Contains(f.Description.ToLower()));

            var totalRecords = await query.CountAsync();

            var data = await query
                .Skip((f.Page - 1) * f.Size)
                .Take(f.Size)
                .ToListAsync();

            return new Response<ResponseGetList<IEnumerable<Category>>>
            {
                StatusCode = (int)HttpStatusCode.OK,
                Message = "Success",
                Content = new ResponseGetList<IEnumerable<Category>>
                {
                    Data = data,
                    Page = f.Page,
                    Size = f.Size,
                    TotalRecords = totalRecords
                }
            };
        }
    }
