namespace InventoryModels;
public abstract class InventoryItem : IInventoryItem
{
    public abstract int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

}