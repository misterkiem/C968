namespace InventoryManager.Models;

public class Outsourced : Part
{
    public string CompanyName { get; set; } = string.Empty;

    public Outsourced() { }
    public Outsourced(InventoryItem item) : base(item) { }
}
