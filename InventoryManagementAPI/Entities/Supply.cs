namespace InventoryManagementAPI.Entities;

public class Supply : BaseEntity
{
    public int Quantity { get; set; }
    public DateTime SupplyDate { get; set; }
    
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; } = null!;
}