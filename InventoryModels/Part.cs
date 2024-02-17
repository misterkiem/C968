namespace InventoryModels;

public abstract class Part : InventoryItem
{
    public int PartID { get => Id; set => Id = value; }

    public Part(InventoryItem item) : base(item) { }
    public Part() { }
}
