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
        string itemFilter = string.Empty;

        [ObservableProperty]
        string cardTitle = string.Empty;

        [ObservableProperty]
        string idHeader = string.Empty;

        [ObservableProperty]
        ICollectionView? _items;

        [ObservableProperty]
        string searchText = string.Empty;


        public void InitItems(IEnumerable<InventoryItem> items)
        {
            var view = CollectionViewSource.GetDefaultView(items);
            view.SortDescriptions.Add(new SortDescription(nameof(InventoryItem.Id), ListSortDirection.Ascending));
            view.Filter = item => CheckFilter((InventoryItem)item);
            Items = view;
        }

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

    } 
}
