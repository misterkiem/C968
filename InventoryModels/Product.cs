using System.Collections.ObjectModel;

namespace InventoryModels;

public class Product : InventoryItem
{
    public ObservableCollection<Part> AssociatedParts { get; } = new();
    public int ProductID { get => Id; set => Id = value; }

    public void AddAssociatedPart(Part part)
    {
        if (LookupAssociatedPart(part.Id) is not null) return;
        AssociatedParts.Add(part);
    }
    public void RemoveAssociatedPart(Part part)
    {
        AssociatedParts.Remove(part);
    }
    public Part? LookupAssociatedPart(int partID)
    {
        return AssociatedParts.FirstOrDefault(part => part.PartID == partID);
    }

    public Product(InventoryItem item) : base(item) { }
    public Product() { }
}
