using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryModels;
using System.ComponentModel;

namespace InventoryManager.Wpf.Vms;

public partial class InventorySearchBarVm : ObservableObject
{

    [ObservableProperty]
    ICollectionView? _items;

    string itemFilter = string.Empty;

    [ObservableProperty]
    string searchText = string.Empty;

    [RelayCommand]
    void Search()
    {
        itemFilter = SearchText;
        Items?.Refresh();
    }

    bool CheckFilter(InventoryItem item)
    {
        return item.Name.ToLower().Contains(itemFilter.ToLower());
    }

    public InventorySearchBarVm(ICollectionView items)
    {
        Items = items;
        Items.Filter = item => CheckFilter((InventoryItem)item);
    }
}
