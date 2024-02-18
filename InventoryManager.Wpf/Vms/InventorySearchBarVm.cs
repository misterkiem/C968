using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Models;
using System.ComponentModel;

namespace InventoryManager.Wpf.Vms;

public partial class InventorySearchBarVm : ObservableObject
{

    [ObservableProperty]
    ICollectionView? _items;

    string itemFilter = string.Empty;

    [ObservableProperty]
    string searchText = string.Empty;

    partial void OnSearchTextChanged(string? oldValue, string newValue) => Items?.Refresh();


    bool CheckFilter(InventoryItem item)
    {
        return item.Name.ToLower().Contains(searchText.ToLower());
    }

    public InventorySearchBarVm(ICollectionView items)
    {
        Items = items;
        Items.Filter = item => CheckFilter((InventoryItem)item);
    }
}
