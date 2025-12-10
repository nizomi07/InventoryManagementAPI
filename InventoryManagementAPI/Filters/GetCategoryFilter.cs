namespace InventoryManagementAPI.Filters;

public class GetCategoryFilter
{
    public int Page { get; set; } = 1;
    public int Size { get; set; } = 10;
    
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
}