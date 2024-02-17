using System.Collections.ObjectModel;

namespace InventoryModels;

public class Inventory
{
    public ObservableCollection<Product> Products { get; set; } = new();
    public ObservableCollection<Part> AllParts { get; set; } = new();

    public int GetNextPartId() => AllParts.Select(p => p.PartID).Max() + 1;
    public int GetNextProductId() => Products.Select(p => p.ProductID).Max() + 1;

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }
    public bool RemoveProduct(int productID)
    {
        var product = LookupProduct(productID);
        if (product is not null)
        {
            Products.Remove(product);
            return true;
        }
        return false;
    }
    public Product? LookupProduct(int productID)
    {
        return Products.FirstOrDefault(product => product.ProductID == productID);
    }
    public void UpdateProduct(int productID, Product newProduct)
    {
        var index = Products.IndexOf(LookupProduct(productID)!);
        Products[index] = newProduct;
        if (index >= 0) { Products[index] = newProduct; }
    }

    public void AddPart(Part part)
    {
        AllParts.Add(part);
    }
    public bool DeletePart(Part part)
    {
        AllParts.Remove(part);
        return true;
    }
    public Part? LookupPart(int partID)
    {
        return AllParts.FirstOrDefault(part => part.PartID == partID);
    }
    public void UpdatePart(int partID, Part part)
    {
        var index = AllParts.IndexOf(LookupPart(partID)!);
        if (index >= 0)
        {
            AllParts[index] = part;
        }
    }
}
