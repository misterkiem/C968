using InventoryModels;

namespace InventoryManager.Wpf.Vms;

public class MainWindowVm
{
    public Inventory Inventory { get; set; } = SampleData.SampleInventory;
    public ItemCardVm PartsCardVm { get; } = new() { CardTitle = "Parts", IdHeader = "Part ID" };
    public ItemCardVm ProductsCardVm { get; } = new() { CardTitle = "Products", IdHeader = "Product ID" };

    public MainWindowVm()
    {
        PartsCardVm.InitItems(Inventory.AllParts);
        ProductsCardVm.InitItems(Inventory.Products);
    }
}
