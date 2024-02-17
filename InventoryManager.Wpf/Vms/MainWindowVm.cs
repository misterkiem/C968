using InventoryModels;

namespace InventoryManager.Wpf.Vms;

public class MainWindowVm
{
    public Inventory Inventory { get; set; } = SampleData.SampleInventory;
    public MainWindowCardVm PartsCardVm { get; } = new() { CardTitle = "Parts", IdHeader = "Part ID" };
    public MainWindowCardVm ProductsCardVm { get; } = new() { CardTitle = "Products", IdHeader = "Product ID" };

    public MainWindowVm()
    {
        PartsCardVm.InitItems(Inventory.AllParts);
        ProductsCardVm.InitItems(Inventory.Products);
    }
}
