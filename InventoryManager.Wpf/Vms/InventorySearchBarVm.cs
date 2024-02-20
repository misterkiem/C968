using CommunityToolkit.Mvvm.ComponentModel;
using InventoryManager.Models;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms;

public partial class InventorySearchBarVm : ObservableObject
{

    IEnumerable<InventoryItem> _itemsSource;
    [ObservableProperty]
    ListCollectionView _items;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(EmptySearch))]
    string searchText = string.Empty;

    public bool EmptySearch => Items.IsEmpty && _itemsSource.Any();

    partial void OnSearchTextChanged(string? oldValue, string newValue) => Items?.Refresh();


    bool CheckFilter(InventoryItem item)
    {
        return item.Name.ToLower().Contains(SearchText.ToLower());
    }

    public InventorySearchBarVm(ListCollectionView itemsView, IEnumerable<InventoryItem> items)
    {
        _itemsSource = items;
        Items = itemsView;
        Items.Filter = item => CheckFilter((InventoryItem)item);
    }
}
