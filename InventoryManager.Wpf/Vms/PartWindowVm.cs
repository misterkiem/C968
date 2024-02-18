using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryModels;

namespace InventoryManager.Wpf.Vms
{
    public partial class PartWindowVm : ObservableObject
    {
        Inventory _inventory;
        public WindowType WindowType { get; set; }

        [ObservableProperty]
        InventoryItemCardVm _cardVm;

        public string? WindowTitle => WindowType switch
        {
            WindowType.AddWindow => "Add Part",
            WindowType.ModifyWindow => "Modify Part",
            _ => null
        };

        [ObservableProperty, NotifyPropertyChangedFor(nameof(IsOutsourced))]
        bool _isInHouse = true;
        public bool IsOutsourced => !IsInHouse;

        [ObservableProperty]
        int? _machineId;

        [ObservableProperty]
        string? _companyName;

        public PartWindowVm(OpenWindowMessage message, Inventory inventory)
        {
            _inventory = inventory;
            var type = message.WindowType;

            WindowType = type;
            if (type == WindowType.AddWindow) { _cardVm = new(inventory.GetNextPartId()); }
            else { _cardVm = new(message.SelectedItem as Part); }

        }

        [RelayCommand]
        void Save()
        {
            if (WindowType == WindowType.AddWindow) AddPart();
            else ReplacePart();
            Messenger.Send(new ClosePartWindowMessage());
        }

        [RelayCommand]
        static void Cancel()
        {
            Messenger.Send(new ClosePartWindowMessage());
        }


        void AddPart()
        {
            var part = GetPart();
            _inventory.AllParts.Add(part);
        }

        void ReplacePart()
        {
            var part = GetPart();
            _inventory.UpdatePart(part.Id, part);

        }

        Part GetPart()
        {
            Part part;
            if (IsInHouse) { part = new Inhouse(CardVm.Item); }
            else { part = new Outsourced(CardVm.Item); }
            return part;
        }
    }
}
