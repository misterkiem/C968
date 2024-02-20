using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Services;
using InventoryManager.Models;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms;

public class MainWindowPartCardVm : MainWindowCardVm
{
    static string displayName = "Part";
    Inventory Inventory { get; set; }

    public MainWindowPartCardVm(IDialogService dialogService, Inventory inventory)
        : base(dialogService, inventory.AllParts)
    {
        Inventory = inventory;
        ItemsView = new(inventory.AllParts);
    }

    public override string DisplayName => displayName;

    public override void DeleteItem()
    {
        if (!ConfirmDelete()) return;
        var productQuery = Inventory.Products.Where(pro => pro.LookupAssociatedPart(SelectedItem!.Id) is not null);
        if (!productQuery.Any())
        {
            ItemsView!.Remove(SelectedItem);
            return;
        }
        var listedProducts = string.Join("\n", productQuery.Select(prod => prod.Name));
        var cantDeleteMessage = $"Can't delete this part because the following product(s) are using it:\n\n" + listedProducts;
        DialogService.DisplayMessage(cantDeleteMessage, "Part in use");

    }
}
