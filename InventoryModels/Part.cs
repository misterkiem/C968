namespace InventoryModels;

public abstract class Part : InventoryItem
{
    public int PartID { get; set; }
    public override int Id { get => PartID; set => PartID = value; }
}
