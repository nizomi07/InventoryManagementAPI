namespace InventoryManagementAPI.DTOs;

public class AddSupplyDTO
{
    public int Quantity { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
    public int ProductId { get; set; }
    public int SupplierId { get; set; }
}