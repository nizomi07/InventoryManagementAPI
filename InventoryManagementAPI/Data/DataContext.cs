using InventoryManagementAPI.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supply> Supplies { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
}