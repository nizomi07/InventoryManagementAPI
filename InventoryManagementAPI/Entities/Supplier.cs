namespace InventoryManagementAPI.Entities;

public class Supplier : BaseEntity
{
    public string CompanyName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public List<Supply> Supplies { get; set; } = new();
}