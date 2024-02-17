using InventoryModels;

namespace InventoryManager.Wpf.Vms;

public class MainWindowVm
{
    public Inventory Inventory { get; set; } = SampleData.SampleInventory;
    public MainWindowCardVm PartsCardVm { get; } 
    public MainWindowCardVm ProductsCardVm { get; }

    public MainWindowVm()
    {
        PartsCardVm = new(Inventory.AllParts) { CardTitle = "Parts", IdHeader = "Part ID" };
        ProductsCardVm = new(Inventory.Products) { CardTitle = "Products", IdHeader = "Product ID" };
    }
}
