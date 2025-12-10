namespace InventoryManagementAPI.Filters;

public class GetSupplierFilter
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    
    public int? Id { get; set; }
    public string? CompanyName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}