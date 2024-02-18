using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryManager.Wpf.Services;
using InventoryModels;
using System.Windows.Data;

namespace InventoryManager.Wpf.Vms
{
    public abstract partial class MainWindowCardVm : ObservableObject
    {
        protected IDialogService DialogService { get; set; }
        public abstract string DisplayName { get; }
        public string CardTitle => DisplayName + "s";

        public string IdHeader => DisplayName + "ID";
        protected string DeleteConfirmMessage => $"Are you sure you want to delete this {DisplayName}?";

        [ObservableProperty]
        ListCollectionView? _itemsView;

        [ObservableProperty]
        InventoryItem? _selectedItem;

        [ObservableProperty]
        InventorySearchBarVm? _searchBarVm;

        public MainWindowCardVm(IDialogService dialogService)
        {
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
            SearchBarVm = new(value);
        }

        [RelayCommand]
        void OpenModifyWindow()
        {
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
