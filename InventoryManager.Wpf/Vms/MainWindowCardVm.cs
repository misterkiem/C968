using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryModels;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms
{
    public partial class MainWindowCardVm : ObservableObject
    {
        public InventoryItemType ItemType { get; set; }

        public string CardTitle => GetCardTitle();

        public string IdHeader => GetIdHeader();

        [ObservableProperty]
        ListCollectionView _itemsView;

        [ObservableProperty]
        InventoryItem? _selectedItem;

        [ObservableProperty]
        InventorySearchBarVm _searchBarVm;

        public MainWindowCardVm(ListCollectionView itemsView, InventoryItemType itemType)
        {
            SearchBarVm = new(itemsView);
            ItemsView = itemsView;
            ItemType = itemType;
        }

        [RelayCommand]
        public void DeleteItem()
        {
            if (SelectedItem is null) return;
            if (ItemsView.Contains(SelectedItem)) { ItemsView.Remove(SelectedItem); }
        }

        [RelayCommand]
        public void OpenAddWindow()
        {
            var message = new OpenWindowMessage(WindowType.AddWindow, ItemType, SelectedItem);
            Messenger.Send(message);
        }

        [RelayCommand]
        void OpenModifyWindow()
        {
            var message = new OpenWindowMessage(WindowType.ModifyWindow, ItemType, SelectedItem);
            Messenger.Send(message);
        }

        string GetCardTitle()
        {
            return ItemType switch
            {
                InventoryItemType.Part => "Parts",
                InventoryItemType.Product => "Products",
                _ => throw new NotImplementedException()
            };
        }

        string GetIdHeader()
        {
            return ItemType switch
            {
                InventoryItemType.Part => "Part ID",
                InventoryItemType.Product => "Product ID",
                _ => throw new NotImplementedException()
            };
        }
    }
}
