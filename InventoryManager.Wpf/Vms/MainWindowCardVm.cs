using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryManager.Wpf.Services;
using InventoryManager.Models;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms
{
    public abstract partial class MainWindowCardVm : ObservableObject
    {
        protected IEnumerable<InventoryItem> _itemsSource;
        protected IDialogService DialogService { get; set; }
        public abstract string DisplayName { get; }
        public string CardTitle => DisplayName + "s";

        public string IdHeader => DisplayName + "ID";
        protected string DeleteConfirmMessage => $"Are you sure you want to delete this {DisplayName}?";
        protected string NoSelectionMessage => $"No {DisplayName} currently selected. Please select a {DisplayName} to modify first.";

        [ObservableProperty]
        ListCollectionView? _itemsView;

        [ObservableProperty]
        InventoryItem? _selectedItem;

        [ObservableProperty]
        InventorySearchBarVm? _searchBarVm;

        public MainWindowCardVm(IDialogService dialogService, IEnumerable<InventoryItem> items)
        {
            _itemsSource = items;
            DialogService = dialogService;
        }

        [RelayCommand]
        public virtual void DeleteItem()
        {
            if (!ConfirmDelete()) return;
            ItemsView!.Remove(SelectedItem!);
        }

        [RelayCommand]
        public void OpenAddWindow()
        {
            var message = new OpenWindowMessage(WindowType.AddWindow, this, SelectedItem);
            Messenger.Send(message);
        }

        partial void OnItemsViewChanged(ListCollectionView? value)
        {
            if (value is null) return;
            SearchBarVm = new(value, _itemsSource);
        }

        [RelayCommand]
        void OpenModifyWindow()
        {
            if (SelectedItem is null)
            {

                DialogService.DisplayMessage(NoSelectionMessage, "Invalid Selection");
                return;
            }
            var message = new OpenWindowMessage(WindowType.ModifyWindow, this, SelectedItem);
            Messenger.Send(message);
        }
        protected bool ConfirmDelete()
        {
            if (SelectedItem is null) return false;
            if (!DialogService.DisplayConfirmMessage(DeleteConfirmMessage, "Confirm Delete")) return false;
            return true;
        }
    }
}
