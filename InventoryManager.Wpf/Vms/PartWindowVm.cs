using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InventoryManager.Wpf.Messages;
using InventoryModels;

namespace InventoryManager.Wpf.Vms
{
    public partial class PartWindowVm : ObservableObject
    {
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
            var type = message.WindowType;
            Part? part = message.SelectedItem as Part;

            WindowType = type; 
            if (type == WindowType.AddWindow)
            {
                _cardVm = new(inventory.GetNextProductId());
            }
            else
            {
                if (part is null) return;
                _cardVm = new(part);
            }

        }

        [RelayCommand]
        void Save()
        {

        }

        [RelayCommand]
        void Cancel()
        {

        }


        void AddPart()
        {
            Part part;
        }

        void ReplacePart()
        {

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
