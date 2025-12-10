namespace InventoryManagementAPI.Filters;

public class GetSupplyFilter
{ 
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    
    public int? Id { get; set; }
    public int? Quantity { get; set; } = null;
    public int? SupplierId { get; set; } = null;
    public int? ProductId { get; set; } = null;
    
}