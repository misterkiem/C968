namespace InventoryModels;
public class InventoryItem : IInventoryItem
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public InventoryItem() { }
    public InventoryItem(InventoryItem item)
    {
        Id = item.Id;
        Name = item.Name;
        Price = item.Price;
        InStock = item.InStock;
        Min = item.Min;
        Max = item.Max;
    }
}