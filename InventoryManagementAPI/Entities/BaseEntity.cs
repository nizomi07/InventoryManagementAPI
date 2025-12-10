using System.ComponentModel.DataAnnotations;

namespace InventoryManagementAPI.Entities;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}