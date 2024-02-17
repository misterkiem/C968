using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms
{
    public partial class MainWindowCardVm : ObservableRecipient
    {
        [ObservableProperty]
        string cardTitle = string.Empty;

        [ObservableProperty]
        string idHeader = string.Empty;

        [ObservableProperty]
        ListCollectionView _itemsView;

        [ObservableProperty]
        InventoryItem? _selectedItem;

        [ObservableProperty]
        InventorySearchBarVm _searchBarVm;

        public MainWindowCardVm(ListCollectionView itemsView)
        {
            SearchBarVm = new(itemsView);
            ItemsView = itemsView;
        }

        [RelayCommand]
        public void DeleteItem()
        {
            if (SelectedItem is null) return;
            if (ItemsView.Contains(SelectedItem)) { ItemsView.Remove(SelectedItem); }

        }
    } 
}
