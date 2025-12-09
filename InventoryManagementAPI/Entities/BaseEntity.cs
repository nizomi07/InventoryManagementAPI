using System.ComponentModel.DataAnnotations;

namespace InventoryManagementAPI.Entities;

public class BaseEntity
{
    [Key]
    public long Id { get; set; }
}