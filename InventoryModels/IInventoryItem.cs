namespace InventoryManager.Models
{
    public interface IInventoryItem
    {
        int Id { get; set; }
        string Name { get; set; }
        int InStock { get; set; }
        decimal Price { get; set; }
        int Min { get; set; }
        int Max { get; set; }
    }
}