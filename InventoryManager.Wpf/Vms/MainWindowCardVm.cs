using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryModels;
using System;
using System.Collections.Generic;
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
        ICollectionView _items;

        [ObservableProperty]
        InventorySearchBarVm _searchBarVm;

        public MainWindowCardVm(IEnumerable<InventoryItem> items)
        {
            var view = CollectionViewSource.GetDefaultView(items);
            SearchBarVm = new(view);
            Items = view;
        }
    } 
}
