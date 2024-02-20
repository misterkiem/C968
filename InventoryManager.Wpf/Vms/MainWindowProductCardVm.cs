using InventoryManager.Models;
using InventoryManager.Wpf.Services;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms
{
    public class MainWindowProductCardVm : MainWindowCardVm
    {
        static string displayName = "Product";

        public MainWindowProductCardVm(IDialogService dialogService, ListCollectionView itemsView, IEnumerable<InventoryItem> itemsSource)
            : base(dialogService, itemsSource) { ItemsView = itemsView; }

        public override string DisplayName => displayName;
    }
}
